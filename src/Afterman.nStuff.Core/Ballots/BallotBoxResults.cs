using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterman.nStuff.Core.Ballots
{
    public class BallotBoxResults
    {
        public BallotBoxResults(List<Ballot> ballots)
        {
            this.Ballots = ballots;
            this.YesVotes = this.Ballots.Where(x => x.YesVote).ToList();
            this.NoVotes = this.Ballots.Where(x => x.YesVote == false).ToList();
        }

        public IList<string> ReasonsForLoss
        {
            get { return this.NoVotes.ConvertAll(x => x.Constituent).ToList(); }
        }

        protected List<Ballot> Ballots;
        public List<Ballot> YesVotes { get; protected set; }

        public bool IsUnanimous => NoVotes.Any() == false;

        public bool IsTie => YesVotes.Count == NoVotes.Count;

        public bool IsNoTurnout => IsTie && YesVotes.Count == 0;

        public List<Ballot> NoVotes { get; protected set; }

        public bool IsTraditionalWin => YesVotes.Count != 0 && YesVotes.Count > NoVotes.Count;

        public bool RenderDecision(bool mustBeUnanimous, bool tieWins, bool noTurnoutWins)
        {
            if (mustBeUnanimous && this.IsUnanimous) return true;
            if (tieWins && IsTie) return true;
            if (noTurnoutWins && IsNoTurnout) return true;
            return IsTraditionalWin;
            ;
        }

    }
    
}
