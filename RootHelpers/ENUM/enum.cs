using System.ComponentModel;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The primary
        /// </summary>
        Primary,

        /// <summary>
        /// The secondary
        /// </summary>
        Secondary,

        /// <summary>
        /// The success
        /// </summary>
        Success,

        /// <summary>
        /// The danger
        /// </summary>
        Danger,

        /// <summary>
        /// The warning
        /// </summary>
        Warning,

        /// <summary>
        /// The information
        /// </summary>
        Info,

        /// <summary>
        /// The light
        /// </summary>
        Light,

        /// <summary>
        /// The dark
        /// </summary>
        Dark
    }

    /// <summary>
    ///
    /// </summary>
    public enum Sizes
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,

        /// <summary>
        /// The larger
        /// </summary>
        Larger,

        /// <summary>
        /// The small
        /// </summary>
        Small,

        /// <summary>
        /// The block
        /// </summary>
        Block
    }

    /// <summary>
    ///
    /// </summary>
    public enum Tooltips
    {
        /// <summary>
        /// The top
        /// </summary>
        top,

        /// <summary>
        /// The right
        /// </summary>
        right,

        /// <summary>
        /// The bottom
        /// </summary>
        bottom,

        /// <summary>
        /// The left
        /// </summary>
        left
    }

    /// <summary>
    ///
    /// </summary>
    public enum Popovers
    {
        /// <summary>
        /// The top
        /// </summary>
        top,

        /// <summary>
        /// The right
        /// </summary>
        right,

        /// <summary>
        /// The bottom
        /// </summary>
        bottom,

        /// <summary>
        /// The left
        /// </summary>
        left
    }

    /// <summary>
    ///
    /// </summary>
    public enum PositionDIV
    {
        /// <summary>
        /// The vertical
        /// </summary>
        Vertical,

        /// <summary>
        /// The horizontal
        /// </summary>
        Horizontal,
    }

    /// <summary>
    ///
    /// </summary>
    public enum ErrorPosition
    {
        /// <summary>
        /// The top
        /// </summary>
        Top,

        /// <summary>
        /// The bottom
        /// </summary>
        Bottom,

        /// <summary>
        /// The align
        /// </summary>
        Align
    }

    /// <summary>
    ///
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// The alert
        /// </summary>
        Alert,

        /// <summary>
        /// The text
        /// </summary>
        Text
    }

    /// <summary>
    /// BForms input elements
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// Text input element
        /// </summary>
        [Description("text")]
        TextBox,
        /// <summary>
        /// Textarea input element
        /// </summary>
        [Description("textarea")]
        TextArea,
        /// <summary>
        /// Password input element
        /// </summary>
        [Description("password")]
        Password, 
        /// <summary>
        /// Url input element
        /// </summary>
        [Description("url")]
        Url,
        /// <summary>
        /// Email input element
        /// </summary>
        [Description("email")]
        Email,
        /// <summary>
        /// Number input element
        /// </summary>
        [Description("number")]
        Number, 
        /// <summary>
        /// Datepicker input element
        /// </summary>
        [Description("date")]
        DatePicker,
         /// <summary>
        /// Time input element
        /// </summary>
        [Description("time")]
        TimePicker, 
        /// <summary>
        /// Checkbox input element
        /// </summary>
        [Description("checkbox")]
        CheckBox,
        /// <summary>
        /// Radio button input element
        /// </summary>
        [Description("radio")]
        RadioButton, 
        /// <summary>
        /// Drop-down list input element
        /// </summary>
        [Description("dropdown")]
        DropDownList,
        /// <summary>
        /// Drop-down list input element
        /// </summary>
        [Description("dropdown")]
        DropDownListwithImage,
        /// <summary>
        /// Listbox input element
        /// </summary>
        [Description("listbox")]
        ListBox, 
        /// <summary>
        /// File upload input element
        /// </summary>
        [Description("file")]
        Upload
    }

}