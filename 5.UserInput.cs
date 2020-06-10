/*
5. User Input [Inheritance] [OOP]

User interface contains two types of user input controls: TextInput, which accepts all characters and NumericInput, which accepts only digits.

Implement the class TextInput that contains:

    Public method void Add(char c) - adds the given character to the current value
    Public method string GetValue() - returns the current value

Implement the class NumericInput that:

    Inherits TextInput
    Overrides the Add method so that each non-numeric character is ignored

https://www.testdome.com/d/c-sharp-interview-questions/18
using System;

public class TextInput {}

public class NumericInput {}

public class UserInput
{
    public static void Main(string[] args)
    {
        //TextInput input = new NumericInput();
        //input.Add('1');
        //input.Add('a');
        //input.Add('0');
        //Console.WriteLine(input.GetValue());
    }
}
*/

// =============================================================== solution (passes 4/4 tests)

using System;

public class TextInput 
{
  protected string value = String.Empty;

  public virtual void Add(char c) {
    this.value += c;
  }

  public string GetValue() {
    return value;
  }
}

public class NumericInput : TextInput
{
  public override void Add(char c) {
    if(System.Char.IsDigit(c)){
      this.value += c;
    }
  }
}

public class UserInput
{
    public static void Main(string[] args)
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}