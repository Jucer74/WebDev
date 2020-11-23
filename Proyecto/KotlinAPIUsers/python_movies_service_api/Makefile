# makefile for medicallocator

BIN=venv/bin/
SHELL=/bin/bash

venv: venv/bin/activate
venv/bin/activate: requirements.txt
	test -d venv || virtualenv -p /usr/bin/python3.7 venv
	venv/bin/pip3 install -Ur requirements.txt
	touch venv/bin/activate

execute:
	python3.7 main.py

clean:
	rm -rf venv