﻿using System;
using System.Configuration;

namespace Providers.Configuration
{
    /// <summary>
    /// Represents a configuration element containing a collection of child elements.
    /// </summary>
    [ConfigurationCollection(
        typeof(BiscuitProviderElement),
        CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap,
        AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
    public class BiscuitProviderElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets the type of the <see cref="T:System.Configuration.ConfigurationElementCollection" />.
        /// </summary>
        /// <returns>The <see cref="T:System.Configuration.ConfigurationElementCollectionType" /> of this collection.</returns>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        /// <summary>
        /// Adds a configuration element to the <see cref="BiscuitProviderElementCollection" />.
        /// </summary>
        /// <param name="provider">
        /// The <see cref="BiscuitProviderElement" /> to add.
        /// </param>
        public void Add(BiscuitProviderElement provider)
        {
            if (provider != null)
            {
                //provider.UpdatePropertyCollection(); ??
                BaseAdd(provider);
            }
        }

        /// <summary>
        /// Adds a configuration element to the <see cref="T:System.Configuration.ConfigurationElementCollection" />.
        /// </summary>
        /// <param name="element">
        /// The <see cref="T:System.Configuration.ConfigurationElement" /> to add.
        /// </param>
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new BiscuitProviderElement();
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.
        /// </summary>
        /// <returns>The name of the collection; otherwise, an empty string. The default is an empty string.</returns>
        protected override String ElementName
        {
            get { return "buiscuitProvider"; }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BiscuitProviderElement)element).Name;
        }

        public void Remove(BiscuitProviderElement details)
        {
            BaseRemove(details);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}