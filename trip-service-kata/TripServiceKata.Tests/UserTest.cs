using Xunit;

namespace TripServiceKata.Tests;

public class UserTests
{
    private static readonly User.User BOB = new User.User();
    private static readonly User.User PAUL = new User.User();

    [Fact]
    public void ShouldInformWhenUsersAreNotFriends()
    {
        User.User user = new User.User();
        user.AddFriend(BOB);

        Assert.False(user.IsFriendsWith(PAUL));
    }

    [Fact]
    public void ShouldInformWhenUsersAreFriends()
    {
        User.User user = new User.User();
        user.AddFriend(BOB);
        user.AddFriend(PAUL);

        Assert.True(user.IsFriendsWith(BOB));
        Assert.True(user.IsFriendsWith(PAUL));
    }
}
