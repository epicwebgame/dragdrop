console.clear();

function throwNonException()
{
  try
    {
      throw 2;
    }
  catch(e)
    {
      console.log(e);
    }
}

throwNonException();