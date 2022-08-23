using System;
using System.Collections.Generic;

namespace ZEDRatApp.ZEDRAT.Utilities
{
	public class PooledBufferManager
	{
		private readonly int _bufferLength;

		private int _bufferCount;

		private readonly Stack<byte[]> _buffers;

		public int BufferLength => this._bufferLength;

		public int MaxBufferCount => this._bufferCount;

		public int BuffersAvailable => this._buffers.Count;

		public bool ClearOnReturn { get; set; }

		public event EventHandler NewBufferAllocated;

		public event EventHandler BufferRequested;

		public event EventHandler BufferReturned;

		protected virtual void OnNewBufferAllocated(EventArgs e)
		{
			this.NewBufferAllocated?.Invoke(this, e);
		}

		protected virtual void OnBufferRequested(EventArgs e)
		{
			this.BufferRequested?.Invoke(this, e);
		}

		protected virtual void OnBufferReturned(EventArgs e)
		{
			this.BufferReturned?.Invoke(this, e);
		}

		public PooledBufferManager(int baseBufferLength, int baseBufferCount)
		{
			if (baseBufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("baseBufferLength", baseBufferLength, "Buffer length must be a positive integer value.");
			}
			if (baseBufferCount <= 0)
			{
				throw new ArgumentOutOfRangeException("baseBufferCount", baseBufferCount, "Buffer count must be a positive integer value.");
			}
			this._bufferLength = baseBufferLength;
			this._bufferCount = baseBufferCount;
			this._buffers = new Stack<byte[]>(baseBufferCount);
			for (int i = 0; i < baseBufferCount; i++)
			{
				this._buffers.Push(new byte[baseBufferLength]);
			}
		}

		public byte[] GetBuffer()
		{
			if (this._buffers.Count > 0)
			{
				lock (this._buffers)
				{
					if (this._buffers.Count > 0)
					{
						return this._buffers.Pop();
					}
				}
			}
			return this.AllocateNewBuffer();
		}

		private byte[] AllocateNewBuffer()
		{
			byte[] result = new byte[this._bufferLength];
			this._bufferCount++;
			this.OnNewBufferAllocated(EventArgs.Empty);
			return result;
		}

		public bool ReturnBuffer(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (buffer.Length != this._bufferLength)
			{
				return false;
			}
			if (this.ClearOnReturn)
			{
				Array.Clear(buffer, 0, buffer.Length);
			}
			lock (this._buffers)
			{
				if (!this._buffers.Contains(buffer))
				{
					this._buffers.Push(buffer);
				}
			}
			return true;
		}

		public void IncreaseBufferCount(int buffersToAdd)
		{
			if (buffersToAdd <= 0)
			{
				throw new ArgumentOutOfRangeException("buffersToAdd", buffersToAdd, "The number of buffers to add must be a nonnegative, nonzero integer.");
			}
			List<byte[]> list = new List<byte[]>(buffersToAdd);
			for (int i = 0; i < buffersToAdd; i++)
			{
				list.Add(new byte[this._bufferLength]);
			}
			lock (this._buffers)
			{
				this._bufferCount += buffersToAdd;
				for (int j = 0; j < buffersToAdd; j++)
				{
					this._buffers.Push(list[j]);
				}
			}
		}

		public int DecreaseBufferCount(int buffersToRemove)
		{
			if (buffersToRemove <= 0)
			{
				throw new ArgumentOutOfRangeException("buffersToRemove", buffersToRemove, "The number of buffers to remove must be a nonnegative, nonzero integer.");
			}
			int num = 0;
			lock (this._buffers)
			{
				for (int i = 0; i < buffersToRemove; i++)
				{
					if (this._buffers.Count > 0)
					{
						this._buffers.Pop();
						num++;
						this._bufferCount--;
						continue;
					}
					return num;
				}
				return num;
			}
		}
	}
}
