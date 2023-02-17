using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stemming
{
    public partial class Stemming : Form
    {

        WordProcessor obj = new WordProcessor();
        public Stemming()
        {
            InitializeComponent();
        }

 

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string input = txtInputText.Text;
            var wordList = input.Split(' ');

            List<string> stem = new List<string>();

            foreach (var word in wordList)
            {                
                stem.Add(obj.GetStem(word));
            }

            Dictionary<string, int> frequency = new Dictionary<string, int>();
            foreach(var term in WordProcessingFilters.WordsFrequency)
            {
                var filter = obj.GetStem(term);
                var cunt = stem.Where(t => t.ToLower().Contains(filter.ToLower())).Count();
                frequency.Add(term, cunt);
            }

            dgvResult.DataSource = frequency.ToList();
        }
    }
}
