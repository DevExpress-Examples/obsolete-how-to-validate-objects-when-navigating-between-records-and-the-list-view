using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinSolution.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
        private string _propertyName1;
        [RuleRequiredField("1", DefaultContexts.Save)]
        public string PropertyName1 {
            get { return _propertyName1; }
            set { SetPropertyValue("PropertyName1", ref _propertyName1, value); }
        }
        private string _propertyName2;
        [RuleRequiredField("2", DefaultContexts.Save)]
        public string PropertyName2 {
            get { return _propertyName2; }
            set { SetPropertyValue("PropertyName2", ref _propertyName2, value); }
        }
    }

}
