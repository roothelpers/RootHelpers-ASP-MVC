using RootHelpers.TOOLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RootHelpers.LIST
{

    /// <summary>
    /// Model type class from BsDateTimeFor and BsDateTime
    /// </summary>
    [Serializable]
    public class DateTime
    {
        /// <summary>
        /// Display value
        /// </summary>
        public string TextValue { get; set; }

        /// <summary>
        /// Datetime value
        /// </summary>
        public System.DateTime? DateValue { get; set; }
    }

    [Serializable]
    public class RangeItem<T>
    {
        /// <summary>
        /// Display value
        /// </summary>
        public string TextValue { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public T ItemValue { get; set; }

        /// <summary>
        /// Bottom limit for ItemValue
        /// </summary>
        public T MinValue
        {
            get
            {
                return _minValue;
            }
            set
            {
                _minValue = value;
                MinValueSet = true;
            }
        }

        /// <summary>
        /// Top limit for ItemValue
        /// </summary>
        public T MaxValue
        {
            get
            {
                return _maxValue;
            }
            set
            {
                _maxValue = value;
                MaxValueSet = true;
            }
        }

        /// <summary>
        /// Display text
        /// </summary>
        public string Display { get; set; }

        private T _minValue;
        private T _maxValue;

        internal bool MinValueSet
        {
            get;
            private set;
        }

        internal bool MaxValueSet
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// Model type class from BsRangeFor
    /// </summary>
    [Serializable]
    public class Range<T>
    {
        /// <summary>
        /// Display value
        /// </summary>
        public string TextValue { get; set; }

        /// <summary>
        /// Begin value
        /// </summary>
        public RangeItem<T> From { get; set; }

        /// <summary>
        /// End value
        /// </summary>
        public RangeItem<T> To { get; set; }
    }

    /// <summary>
    /// Represents the selected item in an instance of the BsSelectList
    /// </summary>
    public class SelectListItem : System.Web.Mvc.SelectListItem
    {
        /// <summary>
        /// Option group unique ID
        /// </summary>
        public string GroupKey { get; set; }

        /// <summary>
        /// Option group display name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The dictionary items are serialized in html as data- attributes
        /// </summary>
        public Dictionary<string, string> Data { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the option should be rendered as a button or inside a select; used for BsMixedButtonGroup component
        /// </summary>
        public bool IsButton { get; set; }
    }

    /// <summary>
    /// Represents a list of items for Dropdown, ListBox, RadioList, CheckboxList binding
    /// </summary>
    public class SelectList<T>
    {
        private T selectedValues;

        /// <summary>
        /// Selected values
        /// </summary>
        public T SelectedValues
        {
            get
            {
                return selectedValues;
            }
            set
            {
                selectedValues = value;
            }
        }

        public static implicit operator T(SelectList<T> value)
        {
            return value.SelectedValues;
        }

        public static implicit operator SelectList<T>(T value)
        {
            return new SelectList<T> { SelectedValues = value };
        }

        public List<SelectListItem> Items { get; set; }

        public SelectList()
        {
            Items = new List<SelectListItem>();
        }

        /// <summary>
        /// Returns all select list items as IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> ToSelectList()
        {
            var list = new List<SelectListItem>();

            foreach (var item in Items)
            {
                list.Add(new SelectListItem
                {
                    Selected = item.Selected,
                    Text = item.Text,
                    Value = item.Value
                });
            }
            return list;
        }

        /// <summary>
        /// Filla BsSelectList.Items with enum vals
        /// </summary>
        public void ItemsFromEnum(System.Type myEnum, params Enum[] excludedVals)
        {
            var enumType = myEnum;
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("myEnum is not of type enum", "myEnum");
            }

            var excludedList = excludedVals.Select(val => ReflectionHelpers.EnumDisplayName(myEnum, val)).ToList();

            foreach (var item in Enum.GetValues(enumType))
            {
                //get Display Name from resources
                var textValue = ReflectionHelpers.EnumDisplayName(myEnum, item as Enum);

                if (excludedList.All(x => x != textValue))
                {
                    this.Items.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = textValue,
                        Value = Convert.ChangeType(item, Enum.GetUnderlyingType(myEnum)).ToString()
                    });
                }
            }
        }

        /// <summary>
        /// Returns a BsSelectList from 
        /// </summary>
        public static SelectList<T> FromSelectList(IEnumerable<SelectListItem> list)
        {
            var bsList = new SelectList<T>();
            foreach (var item in list)
            {
                bsList.Items.Add(new SelectListItem
                {
                    Selected = item.Selected,
                    Text = item.Text,
                    Value = item.Value
                });
            }
            return bsList;
        }

        /// <summary>
        /// Returns a BsSelectList from enum using the DescriptionAttribute
        /// </summary>
        public static SelectList<T> FromEnum(System.Type myEnum)
        {
            var enumType = myEnum;
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("E is not of type enum", "myEnum");
            }

            var bsList = new SelectList<T>();
            foreach (var item in Enum.GetValues(enumType))
            {
                //get Display Name from resources
                var textValue = ReflectionHelpers.EnumDisplayName(myEnum, item as Enum);

                bsList.Items.Add(new SelectListItem
                {
                    Selected = false,
                    Text = textValue,
                    Value = Convert.ChangeType(item, Enum.GetUnderlyingType(myEnum)).ToString()
                });
            }

            return bsList;
        }

    }

}

