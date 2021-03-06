﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using System.Windows.Threading;

//namespace SQLDataProducer
//{


//    public abstract class DelegateAsyncCommand : ICommand
//    {
//        public event EventHandler CanExecuteChanged;
//        public event EventHandler ExecutionStarting;
//        public event EventHandler<AsyncCommandCompleteEventArgs> ExecutionComplete;

//        public abstract string Text { get; }
//        private bool _isExecuting;
//        public bool IsExecuting
//        {
//            get { return _isExecuting; }
//            private set
//            {
//                _isExecuting = value;
//                if (CanExecuteChanged != null)
//                    CanExecuteChanged(this, EventArgs.Empty);
//            }
//        }

//        protected abstract void OnExecute(object parameter);

//        public void Execute(object parameter)
//        {
//            try
//            {
//                IsExecuting = true;
//                if (ExecutionStarting != null)
//                    ExecutionStarting(this, EventArgs.Empty);

//                var dispatcher = Dispatcher.CurrentDispatcher;
//                ThreadPool.QueueUserWorkItem(
//                    obj =>
//                    {
//                        try
//                        {
//                            OnExecute(parameter);
//                            if (ExecutionComplete != null)
//                                dispatcher.Invoke(DispatcherPriority.Normal,
//                                    ExecutionComplete, this,
//                                    new AsyncCommandCompleteEventArgs(null));
//                        }
//                        catch (Exception ex)
//                        {
//                            if (ExecutionComplete != null)
//                                dispatcher.Invoke(DispatcherPriority.Normal,
//                                    ExecutionComplete, this,
//                                    new AsyncCommandCompleteEventArgs(ex));
//                        }
//                        finally
//                        {
//                            dispatcher.Invoke(DispatcherPriority.Normal,
//                                new Action(() => IsExecuting = false));
//                        }
//                    });
//            }
//            catch (Exception ex)
//            {
//                IsExecuting = false;
//                if (ExecutionComplete != null)
//                    ExecutionComplete(this, new AsyncCommandCompleteEventArgs(ex));
//            }
//        }

//        public virtual bool CanExecute(object parameter)
//        {
//            return !IsExecuting;
//        }
//    }
//}