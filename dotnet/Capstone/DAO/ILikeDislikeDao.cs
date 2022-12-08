using Capstone.Models;

namespace Capstone.DAO
{
    public interface ILikeDislikeDao
    {
        LikeDislike GetLikeDislike(int partyId, int guestId);
    }
}