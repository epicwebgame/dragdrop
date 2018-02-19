console.clear();
var x = 5;

switch(x)
  {
    case 1:
      console.log("One");
      break;
    case 2:
      console.log("Two");
      break;
    default:
      console.log("Greater than two");
      break;
    case 3, 4, 5:
      console.log("Flow of control probably won't get here. Oh, it does!");
      break;
  }

switch(x) // without break statements
  {
    case 1:
      console.log("One");
    case 2:
      console.log("Two");
    default:
      console.log("Greater than two");
    case 3, 4, 5:
      console.log("Flow of control probably won't get here. Oh, it does!");
  }