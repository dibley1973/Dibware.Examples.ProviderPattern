using System;
using System.Configuration;

namespace Providers.Configuration.Base
{
    //public class ProviderSettingsCollection : ConfigurationElementCollection
    //{
    //    private static ConfigurationPropertyCollection _properties;

    //    /// <summary>Gets an item from the collection. </summary>
    //    /// <returns>A <see cref="T:System.Configuration.ProviderSettings" /> object contained in the collection.</returns>
    //    /// <param name="key">A string reference to the <see cref="T:System.Configuration.ProviderSettings" /> object within the collection.</param>
    //    public new ProviderSettings this[string key]
    //    {
    //        get
    //        {
    //            return (ProviderSettings)base.BaseGet(key);
    //        }
    //    }

    //    /// <summary>Gets or sets a value at the specified index in the <see cref="T:System.Configuration.ProviderSettingsCollection" /> collection.</summary>
    //    /// <returns>The specified <see cref="T:System.Configuration.ProviderSettings" />.</returns>
    //    /// <param name="index">The index of the <see cref="T:System.Configuration.ProviderSettings" /> to return.</param>
    //    public ProviderSettings this[int index]
    //    {
    //        get
    //        {
    //            return (ProviderSettings)base.BaseGet(index);
    //        }
    //        set
    //        {
    //            if (base.BaseGet(index) != null)
    //            {
    //                base.BaseRemoveAt(index);
    //            }
    //            this.BaseAdd(index, value);
    //        }
    //    }

    //    protected internal override ConfigurationPropertyCollection Properties
    //    {
    //        get
    //        {
    //            return ProviderSettingsCollection._properties;
    //        }
    //    }

    //    static ProviderSettingsCollection()
    //    {
    //        ProviderSettingsCollection._properties = new ConfigurationPropertyCollection();
    //    }

    //    /// <summary>Initializes a new instance of the <see cref="T:System.Configuration.ProviderSettingsCollection" /> class. </summary>
    //    public ProviderSettingsCollection()
    //        : base(StringComparer.OrdinalIgnoreCase)
    //    {
    //    }

    //    /// <summary>Adds a <see cref="T:System.Configuration.ProviderSettings" /> object to the collection.</summary>
    //    /// <param name="provider">The <see cref="T:System.Configuration.ProviderSettings" /> object to add.</param>
    //    public void Add(ProviderSettings provider)
    //    {
    //        if (provider != null)
    //        {
    //            provider.UpdatePropertyCollection();
    //            this.BaseAdd(provider);
    //        }
    //    }

    //    /// <summary>Clears the collection.</summary>
    //    public void Clear()
    //    {
    //        base.BaseClear();
    //    }

    //    protected override ConfigurationElement CreateNewElement()
    //    {
    //        return new ProviderSettings();
    //    }

    //    protected override object GetElementKey(ConfigurationElement element)
    //    {
    //        return ((ProviderSettings)element).Name;
    //    }

    //    /// <summary>Removes an element from the collection.</summary>
    //    /// <param name="name">The name of the <see cref="T:System.Configuration.ProviderSettings" /> object to remove.</param>
    //    public void Remove(string name)
    //    {
    //        base.BaseRemove(name);
    //    }
    //}
}