﻿Public Class Visca
    Private Const HEADER As Byte = &H80
    Private Const COMMAND As Byte = &H1
    Private Const INQUIRY As Byte = &H9
    Private Const TERMINATOR As Byte = &HFF

    Private Const CATEGORY_CAMERA1 As Byte = &H4
    Private Const CATEGORY_PAN_TILTER As Byte = &H6
    Private Const CATEGORY_CAMERA2 As Byte = &H7

    Private Const SUCCESS As Byte = &H0
    Private Const FAILURE As Byte = &HFF

    ' Response types 
    Private Const RESPONSE_CLEAR As Byte = &H40
    Private Const RESPONSE_ADDRESS As Byte = &H30
    Private Const RESPONSE_ACK As Byte = &H40
    Public Const RESPONSE_COMPLETED As Byte = &H50
    Private Const RESPONSE_ERROR As Byte = &H60

    ' Commands/inquiries codes
    Private Const POWER As Byte = &H0
    Private Const DEVICE_INFO As Byte = &H2
    Private Const KEYLOCK As Byte = &H17
    Private Const ID As Byte = &H22
    Private Const ZOOM As Byte = &H7
    Private Const ZOOM_STOP As Byte = &H0
    Private Const ZOOM_TELE As Byte = &H2
    Private Const ZOOM_WIDE As Byte = &H3
    Private Const ZOOM_TELE_SPEED As Byte = &H20
    Private Const ZOOM_WIDE_SPEED As Byte = &H30
    Private Const ZOOM_VALUE As Byte = &H47
    Private Const ZOOM_VALUE_INQ As Byte = &H47
    Private Const ZOOM_FOCUS_VALUE As Byte = &H47
    Private Const DZOOM As Byte = &H6
    Private Const FOCUS As Byte = &H8
    Private Const FOCUS_STOP As Byte = &H0
    Private Const FOCUS_FAR As Byte = &H2
    Private Const FOCUS_NEAR As Byte = &H3
    Private Const FOCUS_FAR_SPEED As Byte = &H20
    Private Const FOCUS_NEAR_SPEED As Byte = &H30
    Private Const FOCUS_VALUE As Byte = &H48
    Private Const FOCUS_MODE_INQ As Byte = &H38
    Private Const FOCUS_MODE_AUTO As Byte = &H2
    Private Const FOCUS_MODE_MANUAL As Byte = &H3
    Private Const FOCUS_MODE_TOGGLE As Byte = &H10
    Private Const FOCUS_AUTO As Byte = &H38
    Private Const FOCUS_AUTO_MAN As Byte = &H10
    Private Const FOCUS_ONE_PUSH As Byte = &H18
    Private Const FOCUS_ONE_PUSH_TRIG As Byte = &H1
    Private Const FOCUS_ONE_PUSH_INF As Byte = &H2
    Private Const FOCUS_AUTO_SENSE As Byte = &H58
    Private Const FOCUS_AUTO_SENSE_HIGH As Byte = &H2
    Private Const FOCUS_AUTO_SENSE_LOW As Byte = &H3
    Private Const FOCUS_NEAR_LIMIT As Byte = &H28
    Private Const WB As Byte = &H35
    Private Const WB_AUTO As Byte = &H0
    Private Const WB_INDOOR As Byte = &H1
    Private Const WB_OUTDOOR As Byte = &H2
    Private Const WB_ONE_PUSH As Byte = &H3
    Private Const WB_ATW As Byte = &H4
    Private Const WB_MANUAL As Byte = &H5
    Private Const WB_ONE_PUSH_TRIG As Byte = &H5
    Private Const RGAIN As Byte = &H3
    Private Const RGAIN_VALUE As Byte = &H43
    Private Const BGAIN As Byte = &H4
    Private Const BGAIN_VALUE As Byte = &H44
    Private Const AUTO_EXP As Byte = &H39
    Private Const AUTO_EXP_FULL_AUTO As Byte = &H0
    Private Const AUTO_EXP_MANUAL As Byte = &H3
    Private Const AUTO_EXP_SHUTTER_PRIORITY As Byte = &HA
    Private Const AUTO_EXP_IRIS_PRIORITY As Byte = &HB
    Private Const AUTO_EXP_GAIN_PRIORITY As Byte = &HC
    Private Const AUTO_EXP_BRIGHT As Byte = &HD
    Private Const AUTO_EXP_SHUTTER_AUTO As Byte = &H1A
    Private Const AUTO_EXP_IRIS_AUTO As Byte = &H1B
    Private Const AUTO_EXP_GAIN_AUTO As Byte = &H1C
    Private Const SLOW_SHUTTER As Byte = &H5A
    Private Const SLOW_SHUTTER_AUTO As Byte = &H2
    Private Const SLOW_SHUTTER_MANUAL As Byte = &H3
    Private Const SHUTTER As Byte = &HA
    Private Const SHUTTER_VALUE As Byte = &H4A
    Private Const IRIS As Byte = &HB
    Private Const IRIS_VALUE As Byte = &H4B
    Private Const GAIN As Byte = &HC
    Private Const GAIN_VALUE As Byte = &H4C
    Private Const BRIGHT As Byte = &HD
    Private Const BRIGHT_VALUE As Byte = &H4D
    Private Const EXP_COMP As Byte = &HE
    Private Const EXP_COMP_POWER As Byte = &H3E
    Private Const EXP_COMP_VALUE As Byte = &H4E
    Private Const BACKLIGHT_COMP As Byte = &H33
    Private Const APERTURE As Byte = &H2
    Private Const APERTURE_VALUE As Byte = &H42
    Private Const ZERO_LUX As Byte = &H1
    Private Const IR_LED As Byte = &H31
    Private Const WIDE_MODE As Byte = &H60
    Private Const WIDE_MODE_OFF As Byte = &H0
    Private Const WIDE_MODE_CINEMA As Byte = &H1
    Private Const WIDE_MODE_16_9 As Byte = &H2
    Private Const MIRROR As Byte = &H61
    Private Const FREEZE As Byte = &H62
    Private Const PICTURE_EFFECT As Byte = &H63
    Private Const PICTURE_EFFECT_OFF As Byte = &H0
    Private Const PICTURE_EFFECT_PASTEL As Byte = &H1
    Private Const PICTURE_EFFECT_NEGATIVE As Byte = &H2
    Private Const PICTURE_EFFECT_SEPIA As Byte = &H3
    Private Const PICTURE_EFFECT_BW As Byte = &H4
    Private Const PICTURE_EFFECT_SOLARIZE As Byte = &H5
    Private Const PICTURE_EFFECT_MOSAIC As Byte = &H6
    Private Const PICTURE_EFFECT_SLIM As Byte = &H7
    Private Const PICTURE_EFFECT_STRETCH As Byte = &H8
    Private Const DIGITAL_EFFECT As Byte = &H64
    Private Const DIGITAL_EFFECT_OFF As Byte = &H0
    Private Const DIGITAL_EFFECT_STILL As Byte = &H1
    Private Const DIGITAL_EFFECT_FLASH As Byte = &H2
    Private Const DIGITAL_EFFECT_LUMI As Byte = &H3
    Private Const DIGITAL_EFFECT_TRAIL As Byte = &H4
    Private Const DIGITAL_EFFECT_LEVEL As Byte = &H65
    Private Const MEMORY As Byte = &H3F
    Private Const MEMORY_RESET As Byte = &H0
    Private Const MEMORY_SET As Byte = &H1
    Private Const MEMORY_RECALL As Byte = &H2
    Private Const MEMORY_RECALL_SPEED As Byte = &H1
    Private Const DISPLAY As Byte = &H15
    Private Const DISPLAY_TOGGLE As Byte = &H10
    Private Const DATE_TIME_SET As Byte = &H70
    Private Const DATE_DISPLAY As Byte = &H71
    Private Const TIME_DISPLAY As Byte = &H72
    Private Const TITLE_DISPLAY As Byte = &H74
    Private Const TITLE_DISPLAY_CLEAR As Byte = &H0
    Private Const TITLE_SET As Byte = &H73
    Private Const TITLE_SET_PARAMS As Byte = &H0
    Private Const TITLE_SET_PART1 As Byte = &H1
    Private Const TITLE_SET_PART2 As Byte = &H2
    Private Const IRRECEIVE As Byte = &H8
    Private Const IRRECEIVE_ON As Byte = &H2
    Private Const IRRECEIVE_OFF As Byte = &H3
    Private Const IRRECEIVE_ONOFF As Byte = &H10
    Private Const PT_DRIVE As Byte = &H1
    Private Const PT_DRIVE_HORIZ_LEFT As Byte = &H1
    Private Const PT_DRIVE_HORIZ_RIGHT As Byte = &H2
    Private Const PT_DRIVE_HORIZ_STOP As Byte = &H3
    Private Const PT_DRIVE_VERT_UP As Byte = &H1
    Private Const PT_DRIVE_VERT_DOWN As Byte = &H2
    Private Const PT_DRIVE_VERT_STOP As Byte = &H3
    Private Const PT_ABSOLUTE_POSITION As Byte = &H2
    Private Const PT_RELATIVE_POSITION As Byte = &H3
    Private Const PT_HOME As Byte = &H4
    Private Const PT_RESET As Byte = &H5
    Private Const PT_LIMITSET As Byte = &H7
    Private Const PT_LIMITSET_SET As Byte = &H0
    Private Const PT_LIMITSET_CLEAR As Byte = &H1
    Private Const PT_LIMITSET_SET_UR As Byte = &H1
    Private Const PT_LIMITSET_SET_DL As Byte = &H0
    Private Const PT_DATASCREEN As Byte = &H6
    Private Const PT_DATASCREEN_ON As Byte = &H2
    Private Const PT_DATASCREEN_OFF As Byte = &H3
    Private Const PT_DATASCREEN_ONOFF As Byte = &H10
    Private Const PT_STOP As Byte = &H0

    Private Const PT_VIDEOSYSTEM_INQ As Byte = &H23
    Private Const PT_MODE_INQ As Byte = &H10
    Private Const PT_MAXSPEED_INQ As Byte = &H11
    Private Const PT_POSITION_INQ As Byte = &H12
    Private Const PT_DATASCREEN_INQ As Byte = &H6

    Public Const PAN_MIN_SPEED As Int16 = 1
    Public Const PAN_MAX_SPEED As Int16 = 24
    Public Const TILT_MIN_SPEED As Int16 = 1
    Public Const TILT_MAX_SPEED As Int16 = 20
    Public Const ZOOM_MIN_SPEED As Int16 = 1
    Public Const ZOOM_MAX_SPEED As Int16 = 7

    Public Enum ResponseSize
        ZoomPos = 7
        PTPos = 11
    End Enum

    Public Enum PTHorizontalDirection
        Left = PT_DRIVE_HORIZ_LEFT
        Right = PT_DRIVE_HORIZ_RIGHT
        StopMove = PT_DRIVE_HORIZ_STOP
    End Enum

    Public Enum PTVerticalDirection
        Up = PT_DRIVE_VERT_UP
        Down = PT_DRIVE_VERT_DOWN
        StopMove = PT_DRIVE_VERT_STOP
    End Enum

    Public Enum ZoomDirection
        Plus = ZOOM_TELE_SPEED
        Minus = ZOOM_WIDE_SPEED
    End Enum

    Public Enum FocusMode
        Auto = FOCUS_MODE_AUTO
        Manual = FOCUS_MODE_MANUAL
    End Enum

    Private cameraNumber As Int16
    Private cameraHeader As Byte

    Public Sub New(ByVal cameraNumber As Int16)
        Me.cameraNumber = cameraNumber
        cameraHeader = HEADER Or Me.cameraNumber
    End Sub


    Public Function InquireZoomPosition() As Byte()
        Return New Byte() {
            cameraHeader,
            INQUIRY,
            CATEGORY_CAMERA1,
            ZOOM_VALUE_INQ,
            TERMINATOR
        }
    End Function

    Public Function InquirePanTiltPosition() As Byte()
        Return New Byte() {
            cameraHeader,
            INQUIRY,
            CATEGORY_PAN_TILTER,
            PT_POSITION_INQ,
            TERMINATOR
        }
    End Function

    Public Function InquireFocusMode() As Byte()
        Return New Byte() {
            cameraHeader,
            INQUIRY,
            CATEGORY_CAMERA1,
            FOCUS_MODE_INQ,
            TERMINATOR
        }
    End Function
    Public Function InquireFocusPos() As Byte()
        Return New Byte() {
            cameraHeader,
            INQUIRY,
            CATEGORY_CAMERA1,
            FOCUS_VALUE,
            TERMINATOR
        }
    End Function

    Public Function PTStop() As Byte()
        Return PTMove()
    End Function

    Public Function PTHome() As Byte()
        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_PAN_TILTER,
            PT_HOME,
            TERMINATOR
        }
    End Function

    Public Function PTMove(Optional horizontalDirection As PTHorizontalDirection = PTHorizontalDirection.StopMove,
                           Optional verticalDirection As PTVerticalDirection = PTHorizontalDirection.StopMove,
                           Optional horizontalSpeed As Int16 = 1,
                           Optional verticalSpeed As Int16 = 1) As Byte()

        If horizontalSpeed > PAN_MAX_SPEED Then
            horizontalSpeed = PAN_MAX_SPEED
        End If
        If verticalSpeed > TILT_MAX_SPEED Then
            verticalSpeed = TILT_MAX_SPEED
        End If

        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_PAN_TILTER,
            PT_DRIVE,
            horizontalSpeed,
            verticalSpeed,
            horizontalDirection,
            verticalDirection,
            TERMINATOR
        }
    End Function

    Public Function PTMoveAbsolute(horizontalPosition As Int16,
                                   verticalPosition As Int16,
                                   Optional horizontalSpeed As Byte = 1,
                                   Optional verticalSpeed As Byte = 1) As Byte()

        Dim pan = parsePositionFromInt16(horizontalPosition)
        Dim tilt = parsePositionFromInt16(verticalPosition)


        If horizontalSpeed > PAN_MAX_SPEED Then
            horizontalSpeed = PAN_MAX_SPEED
        End If
        If verticalSpeed > TILT_MAX_SPEED Then
            verticalSpeed = TILT_MAX_SPEED
        End If

        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_PAN_TILTER,
            PT_ABSOLUTE_POSITION,
            horizontalSpeed,
            verticalSpeed,
            pan(0),
            pan(1),
            pan(2),
            pan(3),
            tilt(0),
            tilt(1),
            tilt(2),
            tilt(3),
            TERMINATOR
            }
    End Function

    Function ZoomStop()
        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_CAMERA1,
            ZOOM,
            ZOOM_STOP,
            TERMINATOR
        }
    End Function

    Function ZoomMove(zoomDir As ZoomDirection, Optional speed As Int16 = 0)
        If speed > ZOOM_MAX_SPEED Then
            speed = ZOOM_MAX_SPEED
        End If
        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_CAMERA1,
            ZOOM,
            zoomDir Or speed,
            TERMINATOR
        }
    End Function

    Function FocusSetMode(mode As FocusMode)
        Return New Byte() {
            cameraHeader,
            COMMAND,
            CATEGORY_CAMERA1,
            FOCUS_AUTO,
            mode,
            TERMINATOR
        }
    End Function

    Public Function getResponse(bytes As Byte(), expectedResponseSize As Integer) As Byte()
        Dim initialPos = 0
        For i As Integer = 0 To bytes.Length - 1
            If bytes(i) = &HFF Then
                Dim size = i - initialPos
                Dim response(size) As Byte
                Array.Copy(bytes, initialPos, response, 0, size + 1)
                initialPos = i + 1
                If response(1) = Visca.RESPONSE_COMPLETED And
                    size = expectedResponseSize - 1 Then
                    Return response
                End If
            End If
        Next
        Return Nothing
    End Function

    Public Function parsePanPosition(response As Byte()) As Int16
        Return parseInt16FromResponse(
            {response(2), response(3), response(4), response(5)}
            )
    End Function

    Public Function parseTiltPosition(response As Byte()) As Int16
        Return parseInt16FromResponse(
            {response(6), response(7), response(8), response(9)}
            )
    End Function

    Public Function parseZoomPosition(response As Byte()) As Int16
        Return parseInt16FromResponse(
            {response(2), response(3), response(4), response(5)}
            )
    End Function

    Public Function parseFocusPosition(response As Byte()) As Int16
        Return parseInt16FromResponse(
            {response(2), response(3), response(4), response(5)}
            )
    End Function

    Public Function parsePositionFromInt16(pos As Int16) As Byte()
        Dim convTemp(1) As Byte
        convTemp(0) = BitConverter.GetBytes(pos)(0)
        convTemp(1) = BitConverter.GetBytes(pos)(1)

        If (BitConverter.IsLittleEndian) Then
            Array.Reverse(convTemp)
        End If

        Dim result(3) As Byte
        result(0) = (convTemp(0) And &HF0) >> 4
        result(1) = convTemp(0) And &HF
        result(2) = (convTemp(1) And &HF0) >> 4
        result(3) = convTemp(1) And &HF

        Return result

    End Function

    Private Function parseInt16FromResponse(data As Byte()) As Int16
        Dim result(1) As Byte
        result(0) = data(0)
        result(0) = result(0) << 4
        result(0) = result(0) Or data(1)

        result(1) = data(2)
        result(1) = result(1) << 4
        result(1) = result(1) Or data(3)

        If (BitConverter.IsLittleEndian) Then
            Array.Reverse(result)
        End If

        Return BitConverter.ToInt16(result, 0)
    End Function

    Public Function SetPreset(id As Byte) As Byte()
        Return New Byte() {
           cameraHeader,
           COMMAND,
           CATEGORY_CAMERA1,
           MEMORY,
           MEMORY_SET,
           id,
           TERMINATOR
       }
    End Function

    Public Function GetPreset(id As Byte) As Byte()
        Return New Byte() {
           cameraHeader,
           COMMAND,
           CATEGORY_CAMERA1,
           MEMORY,
           MEMORY_RECALL,
           id,
           TERMINATOR
       }
    End Function

    Public Function PresetSpeed(speed As Byte) As Byte()
        If speed > PAN_MAX_SPEED Then
            speed = PAN_MAX_SPEED
        End If
        Return New Byte() {
          cameraHeader,
          COMMAND,
          CATEGORY_PAN_TILTER,
          MEMORY_RECALL_SPEED,
          speed,
          TERMINATOR
      }
    End Function

End Class
