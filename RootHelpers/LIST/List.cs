using System;

namespace RootHelpers
{
    #region Accordion

    /// <summary>
    ///
    /// </summary>
    public class Accordion
    {
        /// <summary>
        /// Gets or sets the accordion item.
        /// </summary>
        /// <value>
        /// The accordion item.
        /// </value>
        public String AccordionItem { get; set; }

        /// <summary>
        /// Gets or sets the accordionbody.
        /// </summary>
        /// <value>
        /// The accordionbody.
        /// </value>
        public String Accordionbody { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Int32 Pos { get; set; }
    }

    #endregion Accordion

    #region dropdowns

    /// <summary>
    ///
    /// </summary>
    public class dropdowns
    {
        /// <summary>
        /// Gets or sets the dropdowns item.
        /// </summary>
        /// <value>
        /// The dropdowns item.
        /// </value>
        public String dropdownsItem { get; set; }

        /// <summary>
        /// Gets or sets the dropdownshref.
        /// </summary>
        /// <value>
        /// The dropdownshref.
        /// </value>
        public String dropdownshref { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Int32 Pos { get; set; }

        /// <summary>
        /// The divider
        /// </summary>
        private Boolean _divider = false;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="dropdowns"/> is divider.
        /// </summary>
        /// <value>
        ///   <c>true</c> if divider; otherwise, <c>false</c>.
        /// </value>
        public Boolean divider
        {
            get
            {
                return this._divider;
            }
            set
            {
                this._divider = value;
            }
        }
    }

    #endregion dropdowns

    #region forms

    /// <summary>
    ///
    /// </summary>
    public class Forms
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public PositionDIV Position { get; set; }

        /// <summary>
        /// Gets or sets the error position.
        /// </summary>
        /// <value>
        /// The error position.
        /// </value>
        public ErrorPosition ErrorPosition { get; set; }

        /// <summary>
        /// Gets or sets the type of the error.
        /// </summary>
        /// <value>
        /// The type of the error.
        /// </value>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// The border
        /// </summary>
        private Boolean _border = false;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Forms"/> is border.
        /// </summary>
        /// <value>
        ///   <c>true</c> if border; otherwise, <c>false</c>.
        /// </value>
        public Boolean Border
        {
            get
            {
                return this._border;
            }
            set
            {
                this._border = value;
            }
        }
    }

    #endregion forms

    #region Breadcrumbs

    public class Breadcrumb
    {
        public String Label { get; set; }
        public String ControllerName { get; set; }
        public String ActionName { get; set; }
        public int Pos { get; set; }
    }

    #endregion Breadcrumbs
}