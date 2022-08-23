using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace HYDRA_PROTECTOR
{
	internal class Block
	{
		public List<Instruction> Instructions { get; set; }

		public int Number { get; set; }

		public int Next { get; set; }

		public Block()
		{
			this.Instructions = new List<Instruction>();
		}
	}
}
