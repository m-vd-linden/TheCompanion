#define LEDARRAY_D 9
#define LEDARRAY_C 8
#define LEDARRAY_B 7
#define LEDARRAY_A 6
#define LEDARRAY_G 5
#define LEDARRAY_DI 4
#define LEDARRAY_CLK 3
#define LEDARRAY_LAT 2

int RightLegForward = 22;
int RightLegBackward = 23;
int LeftLegForward = 27;
int LeftLegBackward = 26;
int RightArmForward = 30;
int RightArmBackward = 31;
int LeftArmForward = 35;
int LeftArmBackward = 34; 
int LeftHandForward = 38;
int LeftHandBackward = 39;
int RightHandForward = 42;
int RightHandBackward = 43;

unsigned char ToShowScene[16][16]
{
  {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
  {1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
  {0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1},
  {0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1},
  {1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
  {1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
};

String message;
String value;
int incomingByte = 0;
bool isMessageReal = false;
bool isValueReal = false;
unsigned char Display_Buffer[2];
unsigned int Word1[32];

bool rps = false;
long currTime;
int rpsCounter;

bool driveForward = false;
long timeOne;
int timeUntilOne;

bool driveBackward = false;
long timeTwo;
int timeUntilTwo;

bool driveRight = false;
long timeThree;
int timeUntilThree;

bool driveLeft = false;
long timeFour;
int timeUntilFour;

bool rightArmForward = false;
long timeFive;
int timeUntilFive;

bool rightArmBackward = false;
long timeSix;
int timeUntilSix;

bool leftArmForward = false;
long timeSeven;
int timeUntilSeven;

bool leftArmBackward = false;
long timeEight;
int timeUntilEight;

bool rightHandForward = false;
long timeNine;
int timeUntilNine;

bool rightHandBackward = false;
long timeTen;
int timeUntilTen;

bool leftHandForward = false;
long timeEleven;
int timeUntilEleven;

bool leftHandBackward = false;
long timeTwelve;
int timeUntilTwelve;

void setup() {
  // put your setup code here, to run once:
  pinMode(LEDARRAY_D, OUTPUT); 
  pinMode(LEDARRAY_C, OUTPUT);
  pinMode(LEDARRAY_B, OUTPUT);
  pinMode(LEDARRAY_A, OUTPUT);
  pinMode(LEDARRAY_G, OUTPUT);
  pinMode(LEDARRAY_DI, OUTPUT);
  pinMode(LEDARRAY_CLK, OUTPUT);
  pinMode(LEDARRAY_LAT, OUTPUT);
  Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  while (Serial.available() > 0) 
    {
      incomingByte = Serial.read();
      char receivedCharacter = (char) incomingByte;
      GenerateMessage(receivedCharacter);
      delay(5);
    }
  update(ToShowScene);
  Display(Word1);

  if (rps)
  {
    RockPaperScissor();
  }
  if(driveForward && millis() - timeOne > timeUntilOne)
  {
    driveForward = false;
    MDriveForwardOff();
  }
  if(driveBackward && millis() - timeTwo > timeUntilTwo)
  {
    driveBackward = false;
    MDriveBackwardOff();
  }
  if(driveRight && millis() - timeThree > timeUntilThree)
  {
    driveRight = false;
    MDriveRightOff();
  }
  if(driveLeft && millis() - timeFour > timeUntilFour)
  {
    driveLeft = false;
    MDriveLeftOff();
  }
  if(rightArmForward && millis() - timeFive > timeUntilFive)
  {
    rightArmForward = false;
    MRightArmForwardOff();
  }
  if(rightArmBackward && millis() - timeSix > timeUntilSix)
  {
    rightArmBackward = false;
    MRightArmBackwardOff();
  }
  if(leftArmForward && millis() - timeSeven > timeUntilSeven)
  {
    leftArmForward = false;
    MLeftArmForwardOff();
  }
  if(leftArmBackward && millis() - timeEight > timeUntilEight)
  {
    leftArmBackward = false;
    MLeftArmBackwardOff();
  }
  if(rightHandForward && millis() - timeNine > timeUntilNine)
  {
    rightHandForward = false;
    MRightHandForwardOff();
  }
  if(rightHandBackward && millis() - timeTen > timeUntilTen)
  {
    rightHandBackward = false;
    MRightHandBackwardOff();
  }
  if(leftHandForward && millis() - timeEleven > timeUntilEleven)
  {
    leftHandForward = false;
    MLeftHandForwardOff();
  }
  if(leftHandBackward && millis() - timeOne > timeUntilOne)
  {
    leftHandBackward = false;
    MLeftHandBackwardOff();
  }
}
