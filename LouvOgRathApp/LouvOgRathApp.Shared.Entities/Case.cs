using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    public class Case
    {
        #region Fields
        int id;
        string caseKind;
        int lawyerId;
        int clientId;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Case() { }

        /// <summary>
        /// Constructor used, when reading from DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="caseKind"></param>
        /// <param name="lawyerId"></param>
        /// <param name="clientId"></param>
        public Case(int id, string caseKind, int lawyerId, int clientId)
        {
            this.id = id;
            this.caseKind = caseKind;
            this.lawyerId = lawyerId;
            this.clientId = clientId;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Casekind { get => caseKind; set => caseKind = value; }
        public int LawyerId { get => lawyerId; set => lawyerId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        #endregion
    }
}
