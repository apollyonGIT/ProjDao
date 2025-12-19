using Foundations;

namespace Battles.Humans
{
    public class HumanPD : Producer
    {
        public override IMgr imgr => mgr;
        HumanMgr mgr;

        public HumanView model;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("HumanMgr", priority);

            Human cell = new();
            mgr.cells.Add("main", cell);

            var view = Instantiate(model, transform);
            cell.add_view(view);
        }


        public override void call()
        {
        }
    }
}