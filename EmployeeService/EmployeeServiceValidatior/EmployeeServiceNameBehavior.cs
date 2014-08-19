using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceValidatior
{
    public class EmployeeServiceNameBehavior : IEndpointBehavior
    {
        private bool enabled;
        
        internal EmployeeServiceNameBehavior(bool enabled)
        {
            this.enabled = enabled;
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(
          ServiceEndpoint endpoint,
          ClientRuntime clientRuntime)
        {
            if (false == this.enabled)
            {
                return;
            }

            foreach (ClientOperation clientOperation in clientRuntime.Operations)
            {
                clientOperation.ParameterInspectors.Add(
                    new ValidationParameterInspector());
            }

        }

        public void ApplyDispatchBehavior(
           ServiceEndpoint endpoint,
           EndpointDispatcher endpointDispatcher)
        {

            if (false == this.enabled)
            {
                return;
            }

            foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
            {

                dispatchOperation.ParameterInspectors.Add(
                    new ValidationParameterInspector());
            }

        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        {

        }
    }
}
