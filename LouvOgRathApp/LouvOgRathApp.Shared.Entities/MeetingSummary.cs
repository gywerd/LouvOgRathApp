using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LouvOgRathApp.Shared.Entities
{
    public class MeetingSummary
    {
        #region Fields
        int id;
        int caseId;
        DateTime date;
        string summary;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MeetingSummary() { }

        public MeetingSummary(int id, int caseId, DateTime date, string summary)
        {
            this.id = id;
            this.caseId = caseId;
            this.date = date;
            this.summary = summary;
        }
        #endregion

        #region Properties
        public int Id
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
        public int Caseid
        {
            get => id;
            set
            {
                try
                {
                    caseId = value;
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
        public DateTime Date { get => date; set => date = value; }
        public string Summary { get => summary; set => summary = value; }
        #endregion
    }
}
