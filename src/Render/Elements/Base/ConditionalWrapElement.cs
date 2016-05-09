using System;

namespace VierGewinnt.Render {
	/*
	 * An element to conditionally wrap a child element in a WrapElement
	 */
	public class ConditionalWrapElement: WrapElement {
		private Func<bool> condition;
		private WrapElement wrappedChild;

		public ConditionalWrapElement(Func<bool> condition, WrapElement wrapper, Element child): base(child) {
			this.condition = condition;
			this.wrappedChild = wrapper;

			wrapper.setChild(child);
		}

		public override void draw(Buffer canvas) {
			if(this.condition()) {
				wrappedChild.draw(canvas);
			} else {
				child.draw(canvas);
			}
		}
	}
}