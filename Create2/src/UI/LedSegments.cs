namespace Create2.UI
{
  using System;

  [Flags]
  public enum LedSegments : byte
  {
    A = 1,
    B = 2,
    C = 4,
    D = 8,
    E = 16,
    F = 32,
    G = 64
  }
}