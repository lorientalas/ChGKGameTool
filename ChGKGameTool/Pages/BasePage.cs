using ChGKGameTool.Core;
using System.Windows.Controls;

namespace ChGKGameTool
{
    /// <summary>
    /// A base page for all pages to gain functionality
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return mViewModel; }
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;
                // Update the value
                mViewModel = value;

                // Set the data context for this page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePage()
        {
            // Create a default view model
            ViewModel = new VM();
        }

        #endregion
    }
}
