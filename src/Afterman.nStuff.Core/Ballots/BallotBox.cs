using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Ballots
{
    public class BallotBox
    {
        public BallotBoxResults GetResult()
        {
            return new BallotBoxResults(this.Ballots);
        }

        protected List<Ballot> Ballots = new List<Ballot>();

        public void Vote(bool condition, string componentName)
        {
            this.Ballots.Add(new Ballot
            {
                Constituent = componentName,
                YesVote = condition,
            });

        }
    }
}
