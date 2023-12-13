FROM python:3.9

COPY requirements.txt ./

RUN pip install --no-cache-dir --upgrade pip \
  && pip install --no-cache-dir -r requirements.txt

WORKDIR /5
COPY . /5
EXPOSE 5001 
CMD ["python", "app.py"]