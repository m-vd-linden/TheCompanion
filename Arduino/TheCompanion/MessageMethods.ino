void GenerateMessage(char receivedCharacter)
{
  if (receivedCharacter == '#')
  {
    message = "";
    isMessageReal = true;
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
      RockPaperScissor();
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
