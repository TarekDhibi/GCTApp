namespace GCTApplication
{
    public class ActionPersonel : System.Collections.ObjectModel.Collection<PersonelStat>
        {
            public ActionPersonel()
            {
                Add(new PersonelStat ( "a", 10 ));
            }
        }
    }
