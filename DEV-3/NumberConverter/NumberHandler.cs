﻿using System;
using System.Collections;
using System.Text;

namespace NumberConverter
{
  /// <summary>
  /// This class contains methods that handle numbers
  /// </summary>
  public class NumberHandler
  {
    private int systemBase;
    private int number;

    public int SystemBase
    {
      get
      {
        return systemBase;
      }
      set
      {
        if (value < 2 || value > 20)
        {
          throw new ArgumentException();
        }
        systemBase = value;
      }
    }

    public int Number
    {
      get
      {
        return number;
      }
      set
      {
        if (value < 0)
        {
          throw new ArgumentException();
        }
        number = value;
      }
    }

    public NumberHandler(int number, int systemBase)
    {
      Number = number;
      SystemBase = systemBase;
    }

    /// <summary>
    /// method converts the number to the required number system
    /// </summary>
    /// <returns></returns>
    public string ConvertNumber()
    {
      if (Number == 0)
      {
        return 0.ToString();
      }
      StringBuilder newNumber = new StringBuilder();
      ArrayList arrayOfResidues = new ArrayList();

      arrayOfResidues = CalculateRemainderOfDivision();
      arrayOfResidues.Reverse();
      return (systemBase > 10) ? TransformIntoSystemWithLetters(arrayOfResidues) :
        TransformIntoSystemWithoutLetters(arrayOfResidues);
    }

    private string TransformIntoSystemWithoutLetters(ArrayList arrayOfResidues)
    {
      StringBuilder newNumber = new StringBuilder();
      foreach (int modulo in arrayOfResidues)
      {
        newNumber.Append(modulo);
      }
      return newNumber.ToString();
    }

    private string TransformIntoSystemWithLetters(ArrayList arrayOfResidues)
    {
      StringBuilder newNumber = new StringBuilder();
      foreach (int modulo in arrayOfResidues)
      {
        if (modulo >= 10)
        {
          newNumber.Append(ConvertNumberIntoLetter(modulo));
        }
        else
        {
          newNumber.Append(modulo);
        }
      }
      return newNumber.ToString();
    }

    private ArrayList CalculateRemainderOfDivision()
    {
      ArrayList newNumber = new ArrayList();
      while (Number != 0)
      {
        newNumber.Add(Number % SystemBase);
        Number = Number / systemBase;
      }
      return newNumber;
    }

    private char ConvertNumberIntoLetter(int modulo)
    {
      return (char)('A' + modulo - 10);
    }
  }
}