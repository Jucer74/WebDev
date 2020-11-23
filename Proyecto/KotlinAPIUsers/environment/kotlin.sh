#!/usr/bin/env bash

# Install pika
sudo apt-get update -y
sudo apt-get -y install python3-pip git 
sudo pip3 install pika virtualenv
sudo apt-get install -y openjdk-8-jdk
wget https://services.gradle.org/distributions/gradle-5.0-bin.zip -P /tmp
sudo unzip -d /opt/gradle /tmp/gradle-*.zip

cat > /etc/profile.d/gradle.sh <<- "EOF"
export GRADLE_HOME=/opt/gradle/gradle-5.0
export PATH=${GRADLE_HOME}/bin:${PATH}
EOF

sudo chmod +x /etc/profile.d/gradle.sh
source /etc/profile.d/gradle.sh
gradle -v

export LC_ALL="en_US.UTF-8"
export LC_CTYPE="en_US.UTF-8"
sudo dpkg-reconfigure locales

sudo pip3 install --upgrade pip