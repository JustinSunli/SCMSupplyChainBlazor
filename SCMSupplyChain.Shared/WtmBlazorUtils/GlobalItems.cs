using System.Collections.Generic;
using BootstrapBlazor.Components;
using Microsoft.Extensions.Localization;

namespace WtmBlazorUtils
{
    public class GlobalItems
    {

        private IStringLocalizer _local;

        public GlobalItems(IStringLocalizer local)
        {
            _local = local;
        }

        private List<SelectedItem> _searcherBoolItems;
        public List<SelectedItem> SearcherBoolItems
        {
            get
            {
                if (_searcherBoolItems == null)
                {
                    _searcherBoolItems = new List<SelectedItem> {
                    new SelectedItem{ Text = _local["Sys.All"], Value = ""},
                    new SelectedItem{ Text = _local["Sys.Yes"], Value = "True"},
                    new SelectedItem{ Text = _local["Sys.No"], Value = "False"},
                };
                }
                else
                {
                    _searcherBoolItems[0].Text = _local["Sys.All"];
                    _searcherBoolItems[1].Text = _local["Sys.Yes"];
                    _searcherBoolItems[2].Text = _local["Sys.No"];
                }
                return _searcherBoolItems;
            }
        }

        private List<SelectedItem> _boolItems;
        public List<SelectedItem> BoolItems
        {
            get
            {
                if (_boolItems == null)
                {
                    _boolItems = new List<SelectedItem> {
                     new SelectedItem{ Text = _local["Sys.PleaseSelect"], Value = ""},
                   new SelectedItem{ Text = _local["Sys.Yes"], Value = "True"},
                    new SelectedItem{ Text = _local["Sys.No"], Value = "False"},
                };
                }
                else
                {
                    _boolItems[0].Text = _local["Sys.PleaseSelect"];
                    _boolItems[1].Text = _local["Sys.Yes"];
                    _boolItems[2].Text = _local["Sys.No"];
                }
                return _boolItems;
            }
        }

    }
}
