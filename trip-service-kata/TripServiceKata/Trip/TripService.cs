using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip;

public class TripService
{
    public List<Trip> GetTripsByUser(User.User user)
    {
        User.User loggedUser = GetLoggedInUser() ?? throw new UserNotLoggedInException();

        return user.IsFriendsWith(loggedUser)
            ? TripsByUser(user)
            : [];
    }

    protected virtual List<Trip> TripsByUser(User.User user)
    {
        return TripDAO.FindTripsByUser(user);
    }

    protected virtual User.User GetLoggedInUser()
    {
        return UserSession.GetInstance().GetLoggedUser();
    }
}
