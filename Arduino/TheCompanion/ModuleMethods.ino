void RockPaperScissor()
{
  long randNumber = random(0, 3);
  /*
  SwitchScene(ThreeScene);

  delay(1000);

  SwitchScene(TwoScene);

  delay(1000);
  */

  switch(rpsCounter)
  {
    case 3: 
      SwitchScene(ThreeScene);
      break;

    case 2: 
      SwitchScene(TwoScene);
      break;

    case 1: 
      SwitchScene(OneScene);
      break;
  }

  while (millis() - currTime > 1000)
  {
    currTime = millis();
    rpsCounter--;

    if (rpsCounter == 0)
    {
      switch(randNumber)
      {
        case 0:
          SwitchScene(ScissorScene);
          rps = false;
        break;

        case 1:
          SwitchScene(PaperScene);
          rps = false;
        break;

        case 2:
          SwitchScene(RockScene);
          rps = false;
        break;
      }
    }
  }
}
