using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip;

public class TripService(TripDAO tripDAO)
{
    private readonly TripDAO _tripDAO = tripDAO;

    public List<Trip> GetTripsByUser(User.User user, User.User loggedInUser)
    {
        if (loggedInUser == null) throw new UserNotLoggedInException();

        return user.IsFriendsWith(loggedInUser)
            ? _tripDAO.TripsByUser(user)
            : [];
    }
}
