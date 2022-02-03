/*
 * pid.c
 *
 *  Created on: 3 lut 2022
 *      Author: fijew
 */

#include "pid.h"


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

