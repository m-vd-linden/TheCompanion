void GenerateMessage(char receivedCharacter)
{
  if (receivedCharacter == '#')
  {
    message = "";
    isMessageReal = true;
    isValueReal = false;
  }
  else if (receivedCharacter == '<')
  {
    value = "";
    isValueReal = true;
  }
  else if (receivedCharacter == ">" && isValueReal)
  {
    isValueReal = false;
  }
  else if (receivedCharacter == '%' && isMessageReal)
  {
    
    if (message == "EEN")
    {
      Serial.println("EEN ONTVANGEN");
      SwitchScene(OneScene);
    }
    else if (message == "TWEE")
    {
      Serial.println("TWEE ONTVANGEN");
      SwitchScene(TwoScene);
    }
    else if (message == "DRIE")
    {
      Serial.println("DRIE ONTVANGEN");
      SwitchScene(ThreeScene);
    }
    else if (message == "HAPPY")
    {
      Serial.println("HAPPY ONTVANGEN");
      SwitchScene(HappyScene);
    }
    else if (message == "MOTOR")
    {
      digitalWrite(22, LOW);
      digitalWrite(23, LOW);
    }
    else if (message == "RPS")
    {
      rps = true;
      rpsCounter = 3;
      currTime = millis();
    }
    else if (message == "DRIVEFORWARD")
    {
      driveForward = true;
      timeUntillOne = value.toInt();
      timeOne = millis();
      MDriveForward();
    }
    else if (message == "DRIVEBACKWARD")
    {
      driveBackward = true;
      timeUntillTwo = value.toInt();
      timeTwo = millis();
      MDriveBackward();
    }
    else if (message == "DRIVERIGHT")
    {
      driveRight = true;
      timeUntillThree = value.toInt();
      timeThree = millis();
      MDriveRight();
    }
    else if (message == "DRIVELEFT")
    {
      driveLeft = true;
      timeUntillFour = value.toInt();
      timeFour = millis();
      MDriveLeft();
    }
    else if (message == "RIGHTARMFORWARD")
    {
      rightArmForward = true;
      timeUntillFive = value.toInt();
      timeFive = millis();
      MRightArmForward();
    }
    else if (message == "RIGHTARMBACKWARD")
    {
      rightArmBackward = true;
      timeUntillSix = value.toInt();
      timeSix = millis();
      MRightArmBackward();
    }
    else if (message == "LEFTARMFORWARD")
    {
      leftArmForward = true;
      timeUntillSeven = value.toInt();
      timeSeven = millis();
      MLeftArmForward();
    }
    else if (message == "LEFTARMBACKWARD")
    {
      leftArmBackward = true;
      timeUntillEight = value.toInt();
      timeEight = millis();
      MLeftArmBackward();
    }
    else if (message == "RIGHTHANDFORWARD")
    {
      rightHandForward = true;
      timeUntillNine = value.toInt();
      timeNine = millis();
      MRightHandForward();
    }
    else if (message == "RIGHTHANDBACKWARD")
    {
      rightHandBackward = true;
      timeUntillTen = value.toInt();
      timeTen = millis();
      MRightHandBackward();
    }
    else if (message == "LEFTHANDFORWARD")
    {
      leftHandForward = true;
      timeUntillEleven = value.toInt();
      timeEleven = millis();
      MLeftHandForward();
    }
    else if (message == "LEFTHANDBACKWARD")
    {
      leftHandBackward = true;
      timeUntillTwelve = value.toInt();
      timeTwelve = millis();
      MLeftHandBackward();
    }
  }
  else if (isMessageReal)
  {
    if (isValueReal)
    {
      value += receivedCharacter;
    }
    else
    {
      message += receivedCharacter;
    }
  }
}
