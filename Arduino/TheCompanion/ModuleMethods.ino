void RockPaperScissor()
{
  long randNumber = random(0, 3);

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
          Serial.println("#Scissor%");
          rps = false;
        break;

        case 1:
          SwitchScene(PaperScene);
          Serial.println("#Paper%");
          rps = false;
        break;

        case 2:
          SwitchScene(RockScene);
          Serial.println("#Rock%");
          rps = false;
        break;
      }
    }
  }
}

void MDriveForward()
{
  digitalWrite(RightLegForward, HIGH);
  digitalWrite(LeftLegForward, HIGH);
}

void MDriveForwardOff()
{
  digitalWrite(RightLegForward, LOW);
  digitalWrite(LeftLegForward, LOW);
}

void MDriveBackward()
{
  digitalWrite(RightLegBackward, HIGH);
  digitalWrite(LeftLegBackward, HIGH);
}

void MDriveBackwardOff()
{
  digitalWrite(RightLegBackward, LOW);
  digitalWrite(LeftLegBackward, LOW);
}

void MDriveRight()
{
  digitalWrite(LeftLegForward, HIGH);
}

void MDriveRightOff()
{
  digitalWrite(LeftLegForward, LOW);
}

void MDriveLeft()
{
  digitalWrite(RightLegForward, HIGH);
}

void MDriveLeftOff()
{
  digitalWrite(RightLegForward, LOW);
}

void MRightArmForward()
{
  digitalWrite(RightArmForward, HIGH);
}

void MRightArmForwardOff()
{
  digitalWrite(RightArmForward, LOW);
}

void MRightArmBackward()
{
  digitalWrite(RightArmBackward, HIGH);
}

void MRightArmBackwardOff()
{
  digitalWrite(RightArmBackward, LOW);
}

void MLeftArmForward()
{
  digitalWrite(LeftArmForward, HIGH);
}

void MLeftArmForwardOff()
{
  digitalWrite(LeftArmForward, LOW);
}

void MLeftArmBackward()
{
  digitalWrite(LeftArmBackward, HIGH);
}

void MLeftArmBackwardOff()
{
  digitalWrite(LeftArmBackward, LOW);
}

void MRightHandForward()
{
  digitalWrite(RightHandForward, HIGH);
}

void MRightHandForwardOff()
{
  digitalWrite(RightHandForward, LOW);
}

void MRightHandBackward()
{
  digitalWrite(RightHandBackward, HIGH);
}

void MRightHandBackwardOff()
{
  digitalWrite(RightHandBackward, LOW);
}

void MLeftHandForward()
{
  digitalWrite(LeftHandForward, HIGH);
}

void MLeftHandForwardOff()
{
  digitalWrite(LeftHandForward, LOW);
}

void MLeftHandBackward()
{
  digitalWrite(LeftHandBackward, HIGH);
}

void MLeftHandBackwardOff()
{
  digitalWrite(LeftHandBackward, LOW);
}
