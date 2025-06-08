using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip;

public class TripService
{
    public List<Trip> GetTripsByUser(User.User user, User.User loggedInUser)
    {
        if (loggedInUser == null) throw new UserNotLoggedInException();

        return user.IsFriendsWith(loggedInUser)
            ? TripsByUser(user)
            : [];
    }

    protected virtual List<Trip> TripsByUser(User.User user)
    {
        return TripDAO.FindTripsByUser(user);
    }
}
