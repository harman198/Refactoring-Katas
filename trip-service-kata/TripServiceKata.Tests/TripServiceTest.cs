using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using Xunit;

namespace TripServiceKata.Tests;

public class TripServiceTest
{
    private static readonly User.User GUEST = null;
    private static readonly User.User UNUSED_USER = null;
    private static readonly User.User REGISTERED_USER = new User.User();
    private static readonly User.User ANOTHER_USER = new User.User();
    private static readonly Trip.Trip TO_BRAZIL;
    private static readonly Trip.Trip TO_LONDON;

    private readonly TestableTripService _tripService;

    public TripServiceTest()
    {
        _tripService = new TestableTripService();
    }

    [Fact]
    public void ShouldThrowAnExceptionWhenUserIsNotLoggedIn()
    {
        Assert.Throws<UserNotLoggedInException>(() => _tripService.GetTripsByUser(null, GUEST));
    }

    [Fact]
    public void ShouldNotReturnAnyTripWhenUsersAreNotFriends()
    {
        var friend = new User.User();
        friend.AddFriend(ANOTHER_USER);
        friend.AddTrip(TO_BRAZIL);

        var friendTrips = _tripService.GetTripsByUser(friend, REGISTERED_USER);

        Assert.Empty(friendTrips);
    }

    [Fact]
    public void ShouldReturnFriendTripsWhenUsersAreFriends()
    {
        var friend = new User.User();
        friend.AddFriend(REGISTERED_USER);
        friend.AddTrip(TO_BRAZIL);
        friend.AddTrip(TO_LONDON);

        var friendTrips = _tripService.GetTripsByUser(friend, REGISTERED_USER);

        Assert.Equal(2, friendTrips.Count);
    }

    private class TestableTripService : TripService
    {
        protected override List<Trip.Trip> TripsByUser(User.User user)
        {
            return user.Trips();
        }
    }
}
