#define LEDARRAY_D 9
#define LEDARRAY_C 8
#define LEDARRAY_B 7
#define LEDARRAY_A 6
#define LEDARRAY_G 5
#define LEDARRAY_DI 4
#define LEDARRAY_CLK 3
#define LEDARRAY_LAT 2

bool rps;
int rpsCounter;
long currTime;
String message;
String value;
int incomingByte = 0;
bool isMessageReal = false;
bool isValueReal = false;
unsigned char Display_Buffer[2];
unsigned char ToShowScene[16][16];
unsigned int Word1[32];

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
}
