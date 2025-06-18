"""Functions used in preparing Guido's gorgeous lasagna.

Learn about Guido, the creator of the Python language:
https://en.wikipedia.org/wiki/Guido_van_Rossum

This is a module docstring, used to describe the functionality
of a module and its functions and/or classes.
"""

EXPECTED_BAKE_TIME = 40
PREPARATION_TIME_PER_LAYER = 2

def bake_time_remaining(current_bake_time):
    """Calculate the bake time remaining.

    :param elapsed_bake_time: int - baking time already elapsed.
    :return: int - remaining bake time (in minutes) derived from 'EXPECTED_BAKE_TIME'.

    Function that takes the actual minutes the lasagna has been in the oven as
    an argument and returns how many minutes the lasagna still needs to bake
    based on the `EXPECTED_BAKE_TIME`.
    """
    return EXPECTED_BAKE_TIME - current_bake_time

def preparation_time_in_minutes(number_of_layers):
    """Calculate preparation time in minutes.

    :param number_of_layers: int - number of layers in the lasagna.
    :return: int - total preparation time.

    Function that takes in number of layers in the lasagna and returns
    total preparation time.
    """
    return number_of_layers * PREPARATION_TIME_PER_LAYER

def elapsed_time_in_minutes(number_of_layers, elapsed_bake_time):
    """Calculate elapsed time in minutes.

    :param number_of_layers: int - number of layers in the lasagna.
    :param elapsed_bake_time: int - time lasagna has spent in oven already.
    :return: int - total elapsed time (prep + bake).

    Function that takes in the number of layers and elapsed bake time and
    returns total elapsed prep + cook time.
    """
    return preparation_time_in_minutes(number_of_layers) + elapsed_bake_time
