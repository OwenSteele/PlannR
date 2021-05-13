//using Microsoft.AspNetCore.Components;
//using PlannR.App.Infrastructure.Contracts.View;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PlannR.App.Services
//{
//    public class ModalService : IModalService
//    {
//        public event Action<string, RenderFragment> OnShow;
//        public event Action OnClose;

//        public void Show(string modalName, Type fragmentType)
//        {
//            if (fragmentType.BaseType != typeof(ComponentBase))
//            {
//                throw new ArgumentException("Parameter 'fragmentType', must have a base type of 'ComponentBase");
//            }

//            var fragment = new RenderFragment(x => {
//                x.OpenComponent(1, fragmentType);
//                x.CloseComponent();
//            });

//            OnShow?.Invoke(modalName, fragment);
//        }
//        public void Close()
//        {
//            OnClose?.Invoke();
//        }

//    }
//}
