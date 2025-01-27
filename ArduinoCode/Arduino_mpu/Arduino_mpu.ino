#include <Wire.h>
#include <MPU6050.h>

MPU6050 mpu(0x69); // Use the correct I2C address

void setup() {
  Serial.begin(9600);
  Wire.begin();

  Serial.println("Initializing MPU6050...");
  mpu.initialize();

  if (mpu.testConnection()) {
    Serial.println("MPU6050 connection successful!");
  } else {
    Serial.println("MPU6050 connection failed. Check your wiring.");
    while (1); // Halt execution if connection fails
  }
}

void loop() {
  int16_t ax, ay, az; // Accelerometer data
  int16_t gx, gy, gz; // Gyroscope data

  // Read raw accelerometer and gyroscope data
  mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);

  // Send data to Unity in CSV format
  Serial.print(ax);
  Serial.print(",");
  Serial.print(ay);
  Serial.print(",");
  Serial.print(az);
  Serial.print(",");
  Serial.print(gx);
  Serial.print(",");
  Serial.print(gy);
  Serial.print(",");
  Serial.println(gz);

  delay(50); // Adjust delay as needed
}
