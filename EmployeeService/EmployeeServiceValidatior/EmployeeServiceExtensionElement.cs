using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceValidatior
{
    public class EmployeeServiceExtensionElement : BehaviorExtensionElement
    {

        private const string EnabledAttributeName = "enabled";

        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        protected override object CreateBehavior()
        {
            return new EmployeeServiceNameBehavior(this.Enabled);

        }

        public override Type BehaviorType
        {

            get { return typeof(EmployeeServiceNameBehavior); }


        }
    }
}
