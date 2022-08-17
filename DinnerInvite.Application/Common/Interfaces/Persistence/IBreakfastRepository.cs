namespace DinnerInvite.Application.Common.Interfaces.Persistence
{
    public interface IBreakfastRepository
    {
        void CreateBreakFast(DinnerInvite.Domain.Entities.BreakFast breakFast);
        DinnerInvite.Domain.Entities.BreakFast GetBreakFast(string Name);
        DinnerInvite.Domain.Entities.BreakFast UpdateBreakFast(string id,DinnerInvite.Domain.Entities.BreakFast breakFast);
        int DeleteBreakFast(string id);
    }
}