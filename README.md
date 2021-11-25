# FirstProject


import PySimpleGUI as sg
import pandas as pd
import openpyxl as op
from datetime import datetime
from openpyxl.utils import get_column_letter
#import win32com.client as win32
import calendar


FilePath = 'GTP.xlsx'
df = pd.read_excel(FilePath)

sheet = op.load_workbook('GTP.xlsx')
sheetAct = sheet.active

max_column = sheetAct.max_column
max_row = sheetAct.max_row

time = datetime.today().strftime('%d.%m.%Y')

#spec_sheet = sheet['Sheet2']
#u = sheetAct.cell(1,45)
#p = sheetAct.cell(row=1, column=46)
#username = u.value
#password = p.value

sg.theme('BlueMono')

def Registration():
    global df
    layout = [
        [sg.Text("Регистрация")],
        [sg.Text('Име', size=(15, 1)), sg.InputText(key='Име')],
        [sg.Text('Презиме', size=(15, 1)), sg.InputText(key='Презиме')],
        [sg.Text('Фамилия', size=(15, 1)), sg.InputText(key='Фамилия')],
        [sg.Text('Тел.номер', size=(15, 1)), sg.InputText(key='Тел.номер')],
        [sg.Text('Автомобил', size=(15, 1)), sg.Combo(["Audi", "BMW", "Mercedes", "KIA", "Ferrari", "Lambo"], key='Автомобил')],
        [sg.Text('Модел', size=(15, 1)), sg.InputText(key='Модел')],
        [sg.CalendarButton('Дата',size=(14,1)),sg.InputText('')],
        [sg.Button(validation(),size=(15, 1)),sg.InputText('validation')],
        #[sg.Text('Дата', size=(15, 1)), sg.InputText(key='Ден/Месец/Година')],
        [sg.Submit("Запази"), sg.Button("Изтрий"), sg.Exit("Изход")]
    ]

    window = sg.Window('Годишен Технически Преглед', layout)

    while True:
        event, values = window.read()
        if event == sg.WIN_CLOSED or event == "Изход":
            break
        #if event == "Изтрий":
         #   clear_fields()
        if event == "Запази":
            df = df.append(values, ignore_index=True)
            df.to_excel(FilePath, index=False)
            sg.popup("Успешна Регистрация!")
            sg.popup(validation())
          # clear_fields()
            #window.close()


def validation():
    for row in range(2,7):
        for col in range(7,8):
            char = get_column_letter(col)
            result = (sheetAct[char + str(row)].value)
            print(result)
                #Изпращане на имейл

#def clear_fields():
#   for key in values:
#     window[key]('')
#     return None

#def emial_notification():
#    outlook = win32.Dispatch('Outlook.Application')
#    mail = outlook.CreatItem(0)
#    mail.To = 'blagoysimeonovv@gmail.com'
#    mail.Subject = 'Test'
#    mail.Body = 'Message body'
#    mail.HTMLBody = f""" \
#        <html>
#            <head></head>
#            <body>
#                <p> Text,<br><br>
#                    Test date
#                </p>
#            </body>
#        </html>
#    """
#    mail.Send()

def Login_page():
    layout = [
        [sg.Text("Вход")],
        [sg.Text('Потребителско Име', size=(15,1)), sg.InputText(key='Име')],
        [sg.Text('Парола', size=(15,1)), sg.InputText(key='Парола')],
        [sg.Submit("Вход"),sg.Exit("Изход")]
    ]

    window = sg.Window('Годишен Технически Преглед', layout)
    event, values = window.Read()

    if values['Име'] != 'admin' or values['Парола'] != 'admin':
        sg.popup("Грешен потребител или парола!")
    if values['Име'] == 'admin' and values['Парола'] == 'admin':
        window.close()
        Registration()
    if values['Име'] == '' or values['Парола'] == '':
        sg.popup("Моля въведете потребител и парола!")

Login_page()





