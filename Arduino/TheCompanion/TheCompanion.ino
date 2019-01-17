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
int timeUntillOne;

bool driveBackward = false;
long timeTwo;
int timeUntillTwo;

bool driveRight = false;
long timeThree;
int timeUntillThree;

bool driveLeft = false;
long timeFour;
int timeUntillFour;

bool rightArmForward = false;
long timeFive;
int timeUntillFive;

bool rightArmBackward = false;
long timeSix;
int timeUntillSix;

bool leftArmForward = false;
long timeSeven;
int timeUntillSeven;

bool leftArmBackward = false;
long timeEight;
int timeUntillEight;

bool rightHandForward = false;
long timeNine;
int timeUntillNine;

bool rightHandBackward = false;
long timeTen;
int timeUntillTen;

bool leftHandForward = false;
long timeEleven;
int timeUntillEleven;

bool leftHandBackward = false;
long timeTwelve;
int timeUntillTwelve;

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
  if(driveForward && millis() - timeOne > timeUntillOne)
  {
    driveForward = false;
    MDriveForwardOff();
  }
  if(driveBackward && millis() - timeTwo > timeUntillTwo)
  {
    driveBackward = false;
    MDriveBackwardOff();
  }
  if(driveRight && millis() - timeThree > timeUntillThree)
  {
    driveRight = false;
    MDriveRightOff();
  }
  if(driveLeft && millis() - timeFour > timeUntillFour)
  {
    driveLeft = false;
    MDriveLeftOff();
  }
  if(rightArmForward && millis() - timeFive > timeUntillFive)
  {
    rightArmForward = false;
    MRightArmForwardOff();
  }
  if(rightArmBackward && millis() - timeSix > timeUntillSix)
  {
    rightArmBackward = false;
    MRightArmBackwardOff();
  }
  if(leftArmForward && millis() - timeSeven > timeUntillSeven)
  {
    leftArmForward = false;
    MLeftArmForwardOff();
  }
  if(leftArmBackward && millis() - timeEight > timeUntillEight)
  {
    leftArmBackward = false;
    MLeftArmBackwardOff();
  }
  if(rightHandForward && millis() - timeNine > timeUntillNine)
  {
    rightHandForward = false;
    MRightHandForwardOff();
  }
  if(rightHandBackward && millis() - timeTen > timeUntillTen)
  {
    rightHandBackward = false;
    MRightHandBackwardOff();
  }
  if(leftHandForward && millis() - timeEleven > timeUntillEleven)
  {
    leftHandForward = false;
    MLeftHandForwardOff();
  }
  if(leftHandBackward && millis() - timeOne > timeUntillOne)
  {
    leftHandBackward = false;
    MLeftHandBackwardOff();
  }
}
