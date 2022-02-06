/**
  ******************************************************************************
  * @file    pid.c
  * @author  Jakub Fijewski
  * @version V1.0
  * @date    03-Feb-2022
  * @brief   Implementation of Discrete PID regulator
  *
  ******************************************************************************
  */

#ifndef INC_PID_H_
#define INC_PID_H_

/* Config --------------------------------------------------------------------*/

/* Includes ------------------------------------------------------------------*/


typedef struct {
	float Kp;
	float Ki;
	float Kd;
	float dt;
} pid_parametrs_t;

typedef struct {
	pid_parametrs_t p;
	float previous_error, previous_integral;
} pid;

/* Macro ---------------------------------------------------------------------*/

/* Public variables ----------------------------------------------------------*/

/* Public function prototypes ------------------------------------------------*/

/**
 * @brief Calculate value of control signal by discrete PID regulator
 * @param[in] pid Pid struct
 * @param[in] float value of setpoint
 * @param[in] float value of measurement
 * @return value of control signal
 */
float calculate_discrete_pid(pid *pid, float setpoint, float measured, float u_sat);
#endif
