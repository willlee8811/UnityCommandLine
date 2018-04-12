pipeline {
  agent any
  stages {
    stage('Build') {
      parallel {
        stage('Build') {
          steps {
            echo 'Build'
            sh '''#!/bin/bash
 
UNITY_PATH="D:\\Unity\\Editor\\Unity.exe"
PROJECT_PATH="C:\\Program Files (x86)\\Jenkins\\workspace\\UnityCommandLine_master-6QYLZI6LZO7LZ4X2BCK6XHHK3NUXXXK3LPPOAGPXHVBBGKGOBB2Q\\UnityCommandLineBuild-master"
BUILD_LOG_PATH="${PROJECT_PATH}\\build.log"
DESTINATION_PATH="C:\\Users\\willyliao\\Desktop"'''
          }
        }
        stage('Bat') {
          steps {
            bat 'ECHO finish'
          }
        }
      }
    }
    stage('Unity') {
      steps {
        sh '"$UNITY_PATH" -quit -batchmode -projectPath "${PROJECT_PATH}" -executeMethod BuildTool.Build -logFile "${BUILD_LOG_PATH}" -destinationPath "${DESTINATION_PATH}"'
      }
    }
  }
}