using GdUnit4;
using Godot;

using static GdUnit4.Assertions;

namespace SteelTowers.Test;

[TestSuite]
public class ExampleTest
{
	[TestCase]
	public void Dummy()
	{
		AssertBool(true).IsTrue();
	}

	[TestCase]
	[RequireGodotRuntime]
	public void DummyGodot()
	{
		AssertThat(new Node()).IsNotNull();
	}
}
