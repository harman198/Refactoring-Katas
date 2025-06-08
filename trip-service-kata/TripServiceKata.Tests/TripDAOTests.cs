using TripServiceKata.Exception;
using TripServiceKata.Trip;
using Xunit;

namespace TripServiceKata.Tests;

public class TripDAOTests
{
    [Fact]
    public void ShouldThrowExceptionWhenRetrievingUserTrips()
    {
        Assert.Throws<DependendClassCallDuringUnitTestException>(() => new TripDAO().TripsByUser(new User.User()));
    }
}
