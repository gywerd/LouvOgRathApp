using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LouvOgRathApp.Shared.Entities
{
    public class Lawyer : Person
    {
        #region Fields
        int id;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Lawyer() { }

        /// <summary>
        /// Constructor used, when reading from DB
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="personid">int</param>
        /// <param name="name">string</param>
        /// <param name="adr">string</param>
        /// <param name="zip">int</param>
        /// <param name="town">string</param>
        /// <param name="ssn">int</param>
        /// <param name="place">string</param>
        public Lawyer(int id, int personid, string name, string adr, int zip, string town, int ssn, string place = null) : base(personid, name, adr, zip, town, ssn, place)
        {
            this.id = id;
        }
        #endregion

        public Lawyer(int id, Person person) : base(person)
        {
            this.id = id;
        }

        #region Properties
        public int LawId
        {
            get => id;
            set
            {
                try
                {
                    id = value;
                }
                catch (ArgumentOutOfRangeException aor)
                {
                    MessageBox.Show(Convert.ToString(aor));
                    throw;
                }
                catch (ArgumentNullException an)
                {
                    MessageBox.Show(Convert.ToString(an));
                    throw;
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                    throw;
                }

            }
        }
        #endregion
    }
}
