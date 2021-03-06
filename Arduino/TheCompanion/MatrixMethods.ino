void SceneToWord(unsigned char i_Scene[16][16]){
  int i, k, key = 0;
  unsigned int value;
  for(i = 0; i < 16; i++){
    for(k = 0; k < 16; k++){
      if(i < 8){
        value = i_Scene[i][k] << (7 - i);
        Word1[15 - k] += value;
      } else {
        value = i_Scene[i][k] << (15 - i);
        Word1[31 - k] += value;
      }
    }
  }
}

void Display(unsigned int dat[])  {
  unsigned char i;

  for( i = 0 ; i < 16 ; i++ )
  {
    digitalWrite(LEDARRAY_G, HIGH);   
    
    Display_Buffer[0] = dat[i];   
    Display_Buffer[1] = dat[i+16];

    Send(Display_Buffer[1]);
    Send(Display_Buffer[0]);

    digitalWrite(LEDARRAY_LAT, HIGH);          
    delayMicroseconds(1);
  
    digitalWrite(LEDARRAY_LAT, LOW);
    delayMicroseconds(1);

    Scan_Line(i);             

    digitalWrite(LEDARRAY_G, LOW);

    delayMicroseconds(100); 
  } 

}

void Scan_Line( unsigned int m) { 
  switch(m)
  {
    case 0:     
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, LOW);          
      break;
    case 1:         
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, HIGH);     
      break;
    case 2:         
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, LOW);     
      break;
    case 3:         
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, HIGH);    
      break;
    case 4:
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, LOW);     
      break;
    case 5:
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, HIGH);    
      break;
    case 6:
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, LOW);    
      break;
    case 7:
      digitalWrite(LEDARRAY_D, LOW);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, HIGH);     
      break;
    case 8:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, LOW);     
      break;
    case 9:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, HIGH);    
      break;  
    case 10:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, LOW);    
      break;
    case 11:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, LOW);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, HIGH);     
      break;
    case 12:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, LOW);    
      break;
    case 13:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, LOW);digitalWrite(LEDARRAY_A, HIGH);     
      break;
    case 14:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, LOW);     
      break;
    case 15:
      digitalWrite(LEDARRAY_D, HIGH);digitalWrite(LEDARRAY_C, HIGH);digitalWrite(LEDARRAY_B, HIGH);digitalWrite(LEDARRAY_A, HIGH);    
      break;
    default : break;  
  }
}

void Send( unsigned int dat) {
  unsigned char i;
  digitalWrite(LEDARRAY_CLK, LOW);
  delayMicroseconds(1);;  
  digitalWrite(LEDARRAY_LAT, LOW);
  delayMicroseconds(1);;

  for( i = 0 ; i < 8 ; i++ )
  {
    if( dat&0x01 )
    {
      digitalWrite(LEDARRAY_DI, HIGH);  
    }
    else
    {
      digitalWrite(LEDARRAY_DI, LOW);
    }

    delayMicroseconds(1);
    digitalWrite(LEDARRAY_CLK, HIGH);         
      delayMicroseconds(1);
    digitalWrite(LEDARRAY_CLK, LOW);
      delayMicroseconds(1);   
    dat >>= 1;
      
  }     
}

void update(unsigned char inputScene[16][16]){
  clearWord();
  SceneToWord(inputScene);
}

void clearWord(){
  for(int i = 0; i < 32; i++)
    Word1[i] = 0;
}

void SwitchScene(unsigned char inputScene[16][16])
{
  for(int i = 0; i < 16; i++)
  {
    for(int k = 0; k < 16; k++)
    {
      ToShowScene[i][k] = inputScene[i][k];
    }
  }
}
