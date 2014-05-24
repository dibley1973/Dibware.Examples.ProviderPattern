using System.Configuration;

namespace Providers.Configuration.Base
{
    /// <summary>
    /// Represents the configuration elements associated with a provider.
    /// </summary>
    //public class ProviderSettings : ConfigurationElement
    //{
    //    //private readonly ConfigurationProperty _propName = new ConfigurationProperty("name", typeof(string), null, null, ConfigurationProperty.NonEmptyStringValidator, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey);

    //    //private readonly ConfigurationProperty _propType = new ConfigurationProperty("type", typeof(string), "", ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsTypeStringTransformationRequired);

    //    //private ConfigurationPropertyCollection _properties;

    //    //private NameValueCollection _PropertyNameCollection;

    //    ///// <summary>Gets or sets the name of the provider configured by this class.</summary>
    //    ///// <returns>The name of the provider.</returns>
    //    //[ConfigurationProperty("name", IsRequired=true, IsKey=true)]
    //    //public string Name
    //    //{
    //    //    get
    //    //    {
    //    //        return (string)base[this._propName];
    //    //    }
    //    //    set
    //    //    {
    //    //        base[this._propName] = value;
    //    //    }
    //    //}

    //    ///// <summary>Gets a collection of user-defined parameters for the provider.</summary>
    //    ///// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection" /> of parameters for the provider.</returns>
    //    //public NameValueCollection Parameters
    //    //{
    //    //    get
    //    //    {
    //    //        if (this._PropertyNameCollection == null)
    //    //        {
    //    //            lock (this)
    //    //            {
    //    //                if (this._PropertyNameCollection == null)
    //    //                {
    //    //                    this._PropertyNameCollection = new NameValueCollection(StringComparer.Ordinal);
    //    //                    foreach (object _property in this._properties)
    //    //                    {
    //    //                        ConfigurationProperty configurationProperty = (ConfigurationProperty)_property;
    //    //                        if (!(configurationProperty.Name != "name") || !(configurationProperty.Name != "type"))
    //    //                        {
    //    //                            continue;
    //    //                        }
    //    //                        this._PropertyNameCollection.Add(configurationProperty.Name, (string)base[configurationProperty]);
    //    //                    }
    //    //                }
    //    //            }
    //    //        }
    //    //        return this._PropertyNameCollection;
    //    //    }
    //    //}

    //    //protected internal override ConfigurationPropertyCollection Properties
    //    //{
    //    //    get
    //    //    {
    //    //        this.UpdatePropertyCollection();
    //    //        return this._properties;
    //    //    }
    //    //}

    //    ///// <summary>Gets or sets the type of the provider configured by this class.</summary>
    //    ///// <returns>The fully qualified namespace and class name for the type of provider configured by this <see cref="T:System.Configuration.ProviderSettings" /> instance.</returns>
    //    //[ConfigurationProperty("type", IsRequired=true)]
    //    //public string Type
    //    //{
    //    //    get
    //    //    {
    //    //        return (string)base[this._propType];
    //    //    }
    //    //    set
    //    //    {
    //    //        base[this._propType] = value;
    //    //    }
    //    //}

    //    ///// <summary>Initializes a new instance of the <see cref="T:System.Configuration.ProviderSettings" /> class. </summary>
    //    //public ProviderSettings()
    //    //{
    //    //    this._properties = new ConfigurationPropertyCollection()
    //    //    {
    //    //        this._propName,
    //    //        this._propType
    //    //    };
    //    //    this._PropertyNameCollection = null;
    //    //}

    //    ///// <summary>Initializes a new instance of the <see cref="T:System.Configuration.ProviderSettings" /> class. </summary>
    //    ///// <param name="name">The name of the provider to configure settings for.</param>
    //    ///// <param name="type">The type of the provider to configure settings for.</param>
    //    //public ProviderSettings(string name, string type) : this()
    //    //{
    //    //    this.Name = name;
    //    //    this.Type = type;
    //    //}

    //    //private string GetProperty(string PropName)
    //    //{
    //    //    if (this._properties.Contains(PropName))
    //    //    {
    //    //        ConfigurationProperty item = this._properties[PropName];
    //    //        if (item != null)
    //    //        {
    //    //            return (string)base[item];
    //    //        }
    //    //    }
    //    //    return null;
    //    //}

    //    //protected internal override bool IsModified()
    //    //{
    //    //    if (this.UpdatePropertyCollection())
    //    //    {
    //    //        return true;
    //    //    }
    //    //    return base.IsModified();
    //    //}

    //    //protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
    //    //{
    //    //    ConfigurationProperty configurationProperty = new ConfigurationProperty(name, typeof(string), value);
    //    //    this._properties.Add(configurationProperty);
    //    //    base[configurationProperty] = value;
    //    //    this.Parameters[name] = value;
    //    //    return true;
    //    //}

    //    //protected internal override void Reset(ConfigurationElement parentElement)
    //    //{
    //    //    ProviderSettings providerSetting = parentElement as ProviderSettings;
    //    //    if (providerSetting != null)
    //    //    {
    //    //        providerSetting.UpdatePropertyCollection();
    //    //    }
    //    //    base.Reset(parentElement);
    //    //}

    //    //private bool SetProperty(string PropName, string value)
    //    //{
    //    //    ConfigurationProperty configurationProperty = null;
    //    //    if (!this._properties.Contains(PropName))
    //    //    {
    //    //        configurationProperty = new ConfigurationProperty(PropName, typeof(string), null);
    //    //        this._properties.Add(configurationProperty);
    //    //    }
    //    //    else
    //    //    {
    //    //        configurationProperty = this._properties[PropName];
    //    //    }
    //    //    if (configurationProperty == null)
    //    //    {
    //    //        return false;
    //    //    }
    //    //    base[configurationProperty] = value;
    //    //    return true;
    //    //}

    //    //protected internal override void Unmerge(ConfigurationElement sourceElement, ConfigurationElement parentElement, ConfigurationSaveMode saveMode)
    //    //{
    //    //    ProviderSettings providerSetting = parentElement as ProviderSettings;
    //    //    if (providerSetting != null)
    //    //    {
    //    //        providerSetting.UpdatePropertyCollection();
    //    //    }
    //    //    ProviderSettings providerSetting1 = sourceElement as ProviderSettings;
    //    //    if (providerSetting1 != null)
    //    //    {
    //    //        providerSetting1.UpdatePropertyCollection();
    //    //    }
    //    //    base.Unmerge(sourceElement, parentElement, saveMode);
    //    //    this.UpdatePropertyCollection();
    //    //}

    //    //internal bool UpdatePropertyCollection()
    //    //{
    //    //    bool flag = false;
    //    //    ArrayList arrayLists = null;
    //    //    if (this._PropertyNameCollection != null)
    //    //    {
    //    //        foreach (ConfigurationProperty _property in this._properties)
    //    //        {
    //    //            if (!(_property.Name != "name") || !(_property.Name != "type") || this._PropertyNameCollection.Get(_property.Name) != null)
    //    //            {
    //    //                continue;
    //    //            }
    //    //            if (arrayLists == null)
    //    //            {
    //    //                arrayLists = new ArrayList();
    //    //            }
    //    //            if ((base.Values.GetConfigValue(_property.Name).ValueFlags & ConfigurationValueFlags.Locked) != ConfigurationValueFlags.Default)
    //    //            {
    //    //                continue;
    //    //            }
    //    //            arrayLists.Add(_property.Name);
    //    //            flag = true;
    //    //        }
    //    //        if (arrayLists != null)
    //    //        {
    //    //            foreach (string arrayList in arrayLists)
    //    //            {
    //    //                this._properties.Remove(arrayList);
    //    //            }
    //    //        }
    //    //        foreach (string str in this._PropertyNameCollection)
    //    //        {
    //    //            string item = this._PropertyNameCollection[str];
    //    //            string property = this.GetProperty(str);
    //    //            if (property != null && !(item != property))
    //    //            {
    //    //                continue;
    //    //            }
    //    //            this.SetProperty(str, item);
    //    //            flag = true;
    //    //        }
    //    //    }
    //    //    this._PropertyNameCollection = null;
    //    //    return flag;
    //    //}
    //}
}
