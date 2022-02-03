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

/* Includes ------------------------------------------------------------------*/
#include "pid.h"

/* Typedef -------------------------------------------------------------------*/

/* Define --------------------------------------------------------------------*/

/* Macro ---------------------------------------------------------------------*/

/* Private variables ---------------------------------------------------------*/

/* Public variables ----------------------------------------------------------*/

/* Public function prototypes -----------------------------------------------*/
float calculate_discrete_pid(pid *pid, float setpoint, float measured);


/**
 * @brief Calculate value of control signal by discrete PID regulator
 * @param[in] pid Pid struct
 * @param[in] float value of setpoint
 * @param[in] float value of measurement
 * @return value of control signal
 */
float calculate_discrete_pid(pid *pid, float setpoint, float measured) {
	float u = 0, P, I, D, error, integral, derivative;

	error = setpoint - measured;

	//proportional part
	P = pid->p.Kp * error;

	//integral part
	integral = pid->previous_integral + (error + pid->previous_error); //numerical integrator without anti-windup
	pid->previous_integral = integral;
	I = pid->p.Ki * integral * (pid->p.dt / 2.0);

	//derivative part
	derivative = (error - pid->previous_error) / pid->p.dt; //numerical derivative without filter
	pid->previous_error = error;
	D = pid->p.Kd * derivative;

	//sum of all parts
	u = P + I + D; //without saturation

	float u_sat = 0;
	if (u < 0)
		u_sat = 0;
	else if (u > 1998)
		u_sat = 1998;
	else
		u_sat = u;

	return u_sat;
}

